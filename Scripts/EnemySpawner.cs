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

    public void SpawnEnemies()
    {
        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            spawnRate = Random.Range(minRate, maxRate);
            DemageControl.countEnemies++;
            DemageControl.hasSpawnerSpawned = true;
            Instantiate(enemy, transform.position, Quaternion.identity);
        }                    
    }
}
