﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
	public float speed = 20;
	private PlayerController playerControllerScript;
	private float leftbound = -5;
    // Start is called before the first frame update
    void Start()
    {
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
		if(playerControllerScript.gameOver == false)
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}

		if (transform.position.x < leftbound && gameObject.CompareTag("Obstacle"))
		{
			Destroy(gameObject);
		}
		
    }
}
