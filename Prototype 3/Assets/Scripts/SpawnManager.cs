using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	private float startDelay = 2;
	private float stopDelay = 2;
	public GameObject obstaclePrefab;
	private Vector3 spawnPos = new Vector3(30, 0, 0);
	private PlayerController playerControllerScript;
	
    // Start is called before the first frame update
    void Start()
    {
		//Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
		InvokeRepeating("SpawnObstacle", startDelay, stopDelay);
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	}

    // Update is called once per frame
    void Update()
    {

	}
	void SpawnObstacle()
	{
		if (playerControllerScript.gameOver == false)
		{
			Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
		}
	}
}
