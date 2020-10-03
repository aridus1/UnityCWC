﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	public GameObject powerUpPrefab;
	public float spawnRange = 9;
	private int enemyCount;
	private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
		SpawnEnemyWave(waveNumber);
		Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
	}

    // Update is called once per frame
    void Update()
    {
		enemyCount = FindObjectsOfType<EnemyMovement>().Length;
		if (enemyCount == 0)
		{
			waveNumber++;
			SpawnEnemyWave(waveNumber);
			Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
			Debug.Log("Wave " +waveNumber +" spawned");
		}
    }

	void SpawnEnemyWave(int enemiesToSpawn)
	{
		for (int i = 0; i < enemiesToSpawn; i++)
		{
			Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
		}
	}

	private Vector3 GenerateSpawnPosition()
	{
		float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosZ = Random.Range(-spawnRange, spawnRange);
		Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

		return randomPos;
	}
}
