using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public 	Transform lookAt;
	private Transform camTransform;

	public float distance = 20f;

	private float currentX = 0f;
	private float currentY = 0f;

	private const float Y_ANGLE_MIN = -50f;
	private const float Y_ANGLE_MAX = 50f;

	void Start()
	{
		camTransform = Camera.main.transform;
	}

	void Update()
	{
		currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y")*-1;

		currentY = Mathf.Clamp (currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
	}

	void LateUpdate()
	{
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	}
}