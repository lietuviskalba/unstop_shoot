using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;

    private float spawnRate;
    private float nextSpawn;
    private float minRate;
    private float maxRate;
    private int randDir;

    void Start()
    {
        //Set default values here
        spawnRate = 4f;
        minRate = 2f;
        maxRate = 15f;
    }
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            spawnRate = Random.Range(minRate, maxRate);
            randDir = (int)Random.Range(0, 2) * 2 - 1;
            enemy.GetComponent<EnemyBehavior>().SetMoveDir(randDir);
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
