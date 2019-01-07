using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemageControl : MonoBehaviour {

    private GameObject[] spanwers;

    public static int countEnemies;
    public static bool hasSpawnerSpawned;

    public int maxEnemies;
    private int randSpawner;
    public float waitTime;
    private float waitNextSpawn;
    private bool isMaxEnemiesReached;

    void Start () {

        spanwers = GameObject.FindGameObjectsWithTag("Spawner");
        countEnemies = 0;
        waitNextSpawn = waitTime;
        isMaxEnemiesReached = false;
        hasSpawnerSpawned = false;
	}
	
	void Update ()
    {
        if (countEnemies >= maxEnemies)
        {
            isMaxEnemiesReached = true;
        }
        else if (countEnemies <= maxEnemies)
        {
            NextSpawn();
            SpawnEnemies();
            isMaxEnemiesReached = false;
        }
    }

    private void NextSpawn()
    {
        if (hasSpawnerSpawned == true)
        {
            waitNextSpawn -= Time.deltaTime;

            if(waitNextSpawn <= 0)
            {
                hasSpawnerSpawned = false;
                waitNextSpawn = waitTime;
                randSpawner = Random.Range(0, spanwers.Length);
            }
        }
    }
    private void SpawnEnemies()
    {
        if(isMaxEnemiesReached == false  && hasSpawnerSpawned == false)
        {
            try
            {
                spanwers[randSpawner].GetComponent<EnemySpawner>().SpawnEnemies();
            }
            catch
            {
                Debug.LogWarning("Man! There are no spawners in the level!");
            }
        }   
    }
}
