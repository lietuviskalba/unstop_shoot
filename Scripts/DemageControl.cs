using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemageControl : MonoBehaviour {

    private GameObject[] spanwers;

    public int maxEnemies;
    public int minEnemies;

	void Start () {

        spanwers = GameObject.FindGameObjectsWithTag("Spawner");
	}
	
	void Update () {

        int currEnemies = EnemyBehavior.countEnemies;
        bool isSpawnStoped = EnemySpawner.hasSpawningStoped;

        if (currEnemies >= maxEnemies && isSpawnStoped == false)
        {
            EnemySpawner.hasSpawningStoped = true;
        }
        else if (currEnemies <= minEnemies && isSpawnStoped == true)
        {
            EnemySpawner.hasSpawningStoped = false;
        }
    }

    private void SpawnerActivation(bool state)
    {
        foreach (GameObject spawner in spanwers)
        {
            spawner.SetActive(state);
        }
    }
}
