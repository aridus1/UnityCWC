using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 20;
	public float turnSpeed = 10;

	private float verticalInput;
	private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//get user input and convert it to a value
		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");

		// moves the vehicle forward
		transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
		//transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput * verticalInput); //*vertical input here so that the car will turn only when its moving
		transform.Rotate(Vector3.up * horizontalInput * verticalInput);
    }
}
