using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public GameObject player;
	public Vector3 offset = new Vector3(0, 5, -10);	//struct Vector3 represents a vector with 3 single precision float as input values.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	// Update shows camera shaking, so try lateupdate
    void LateUpdate()
    {
		transform.position = player.transform.position + offset;
    }
}
