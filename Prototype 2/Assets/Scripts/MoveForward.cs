using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
	private float upperBound = 30;
	private float lowerBound = -10;
	public float speed = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Destroy the object in case it goes out of bounds
		if (transform.position.z > upperBound)
		{
			Destroy(gameObject);
		}
		else if (transform.position.z < lowerBound)
		{
			Debug.Log("Game Over!");
			Destroy(gameObject);
		}

		transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
