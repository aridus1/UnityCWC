using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject projectilePrefab;
	private float horizontalInput;
	public float speed = 10;
	public float xRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//shoot food
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//launch projectile from a player
			Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
		}

		//player movement
		horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

		if (transform.position.x < -xRange)
		{
			transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); //set x range as +ve to loop around instead of stopping into wall
		}
		else if (transform.position.x > xRange)
		{
			transform.position = new Vector3(xRange, transform.position.y, transform.position.z); //set x range as -ve to loop around instead of stopping into wall
		}
	}
}
