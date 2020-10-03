using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public int pointValue;

	private Rigidbody targetRb;
	private float minSpeed = 12, maxSpeed = 16;
	private float maxTorque = 10;
	private float xRange = 4, ySpawnPos = -2;

	public ParticleSystem explosionParticle;

	private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

		targetRb = GetComponent<Rigidbody>();

		transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
		targetRb.AddForce(RandomForce(), ForceMode.Impulse);
		targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnMouseDown()
	{
		if(gameManager.isGameActive)
		{
			Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
			Destroy(gameObject);
			gameManager.UpdateScore(pointValue);
			if (gameObject.CompareTag("Bad"))
			{
				gameManager.GameOver();
			}
		}
		
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		if (gameObject.CompareTag("Good"))
		{
			gameManager.GameOver();
		}
	}

	Vector3 RandomForce()
	{
		return Vector3.up * Random.Range(minSpeed, maxSpeed);
	}
	Vector3 RandomTorque()
	{
		return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
	}
}
