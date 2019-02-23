using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWave : MonoBehaviour
{
    public int numberOfZombies;
    public Zombie zombie;
    public Player player;
    public Base car;

    private float leftBorder = -3.75f;
    private float rightBorder = 3.72f;
    private float topBorder = 5.27f;
    private float bottomBorder = -5.24f;

    // Start is called before the first frame update
    void Start() { 
        float offset = (rightBorder - leftBorder) / (numberOfZombies+1);
        for (int i = 1; i < numberOfZombies+1; i++)
        {
            Instantiate(zombie, new Vector3(leftBorder + i * offset, topBorder - 0.5f), new Quaternion(0, 0, -90, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
