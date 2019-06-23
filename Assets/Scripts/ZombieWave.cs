using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieWave : MonoBehaviour
{
    public int numberOfZombies;
    public int wavesNumber;
    public Zombie zombie;
    public Player player;
    public Base car;

    public float leftBorder = -9.5f;
    public float rightBorder = 10.6f;
    public float topBorder = 9.5f;
    public float bottomBorder = 8.5f;

    private float offset;
    private int zombieTotal;

    // Start is called before the first frame update
    void Start() {
        zombieTotal = 0;
        offset = (rightBorder - leftBorder) / (numberOfZombies+1);
    }

    void SpawnZombies() {
        for (int i = 1; i < numberOfZombies + 1; i++)
        {
            Instantiate(zombie, new Vector3(leftBorder + i * offset, topBorder - 0.5f), new Quaternion(0, 0, -90, 0));
            zombieTotal++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieTotal == 0) {
            wavesNumber--;
            zombie.damage *= 1.05f;
            zombie.speed *= 1.05f;
            if (wavesNumber > 0)
            {
                SpawnZombies();
            }
            else {
                StartCoroutine(Win());
            }
        }
    }

    IEnumerator Win() {
        yield return new WaitForSeconds(1f);
        if (zombieTotal == 0) {
            SceneManager.LoadScene("WinWindow");
        }
    }

    public void KillZombie() {
        zombieTotal--;
    }
}
