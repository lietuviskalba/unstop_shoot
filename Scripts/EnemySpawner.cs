using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;

    [Range(2f, 15f)]
    public float minRate;
    [Range(2f, 15f)]
    public float maxRate;
    [Range(2f, 10f)]
    public float spawnRate;
    private float nextSpawn;
    private int randDir;

    public static bool hasSpawningStoped;
    private bool delaySpawn;

    void Start()
    {
        hasSpawningStoped = false;
        delaySpawn = true;
        Invoke("SpawnEnemies", 3f);
    }

    void Update()
    {
        MaxEnemies();
    }

    void MaxEnemies()
    {
        if (hasSpawningStoped == true)
        {
            return;
        }

        if (delaySpawn == false)
        {
            SpawnEnemies();
        }         
    }

    private void SpawnEnemies()
    {
        if (Time.time >= nextSpawn)
        {
            delaySpawn = false;
            nextSpawn = Time.time + spawnRate;
            spawnRate = Random.Range(minRate, maxRate);
            randDir = (int)Random.Range(0, 2) * 2 - 1;
            enemy.GetComponent<EnemyBehavior>().ChangeDirGS = randDir;
            Instantiate(enemy, transform.position, Quaternion.identity);
            EnemyBehavior.countEnemies += 1;
        }                    
    }
}
