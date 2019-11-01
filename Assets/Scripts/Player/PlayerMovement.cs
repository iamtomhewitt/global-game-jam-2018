using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float forwardSpeed;
	public float accelerationSpeed;
	public float rotationSpeed;

	public KeyCode accelerateButton;

	void Update()
	{
		transform.position += transform.forward * forwardSpeed * Time.deltaTime;

		if (Input.GetKey (accelerateButton)) 
		{
			transform.position += transform.forward * accelerationSpeed * Time.deltaTime;

			// Only rotate towards the camera direction when we press accelereate
			RotateTowardsCameraDirection ();
		}
	}

	void RotateTowardsCameraDirection()
	{
//		Quaternion lookDirection;
//		Vector3 direction;
//
//		direction = (Camera.main.transform.position - transform.position).normalized;
//
//		lookDirection = Quaternion.LookRotation (-direction);
//
//		transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * rotationSpeed);
		float x = Screen.width / 2f;
		float y = Screen.height / 2f;

		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (x, y, 0f));
		Quaternion look = Quaternion.LookRotation (ray.direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * rotationSpeed);
	}
}
