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

    private float leftBorder = -3.75f;
    private float rightBorder = 3.72f;
    private float topBorder = 5.27f;
    private float bottomBorder = -5.24f;

    private float offset;
    private int zombieTotal;

    // Start is called before the first frame update
    void Start() {
        zombieTotal = 0;
        offset = (rightBorder - leftBorder) / (numberOfZombies+1);
        SpawnZombies();
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
            if (wavesNumber > 0)
            {
                SpawnZombies();
                wavesNumber--;
            }
            else {
                StartCoroutine(Win());
            }
        }
    }

    IEnumerator Win() {
        yield return new WaitForSeconds(1f);
        if (zombieTotal == 0) {
            SceneManager.LoadScene(2);
        }
    }

    public void KillZombie() {
        zombieTotal--;
    }
}
