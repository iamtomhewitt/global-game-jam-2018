using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPodSpawner : MonoBehaviour 
{
	public GameObject dataPod;
	public int maxDataPods;

	public void SpawnDataPods()
	{
		for (int i = 0; i < maxDataPods; i++) 
		{
			float x = Random.Range (Boundary.minX, Boundary.maxX);
			float y = Random.Range (Boundary.minY, Boundary.maxY);
			float z = Random.Range (Boundary.minZ, Boundary.maxZ);

			Vector3 position = new Vector3(x, y, z);

			GameObject d = Instantiate (dataPod, position, Quaternion.identity) as GameObject;
			d.transform.parent = this.transform;
		}
	}
}
