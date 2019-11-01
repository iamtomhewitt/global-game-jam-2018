using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPod : MonoBehaviour 
{
	public float gameTimeValue;

	public void MovePosition()
	{
		float x = Random.Range (Boundary.minX, Boundary.maxX);
		float y = Random.Range (Boundary.minY, Boundary.maxY);
		float z = Random.Range (Boundary.minZ, Boundary.maxZ);

		Vector3 position = new Vector3 (x, y, z);
		transform.position = position;
	}
}
