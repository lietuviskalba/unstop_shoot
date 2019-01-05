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

    void Start()
    {
        hasSpawningStoped = false;
    }

    public void SpawnEnemies()
    {
        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            spawnRate = Random.Range(minRate, maxRate);
            randDir = (int)Random.Range(0, 2) * 2 - 1;
            enemy.GetComponent<EnemyBehavior>().ChangeDirGS = randDir;
            DemageControl.countEnemies++;
            DemageControl.hasSpawnerSpawned = true;
            Instantiate(enemy, transform.position, Quaternion.identity);
        }                    
    }
}
