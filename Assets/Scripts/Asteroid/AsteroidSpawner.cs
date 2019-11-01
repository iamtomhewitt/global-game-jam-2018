using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour 
{
	public GameObject[] asteroids;
	public int maxAsteroids;

	public void SpawnAsteroids()
	{
		for (int i = 0; i < maxAsteroids; i++) 
		{
			int j = Random.Range(0, asteroids.Length);

			float x = Random.Range (Boundary.minX, Boundary.maxX);
			float y = Random.Range (Boundary.minY, Boundary.maxY);
			float z = Random.Range (Boundary.minZ, Boundary.maxZ);

			Vector3 position = new Vector3(x, y, z);
			Vector3 rotation = new Vector3 (Random.Range (-180, 180), Random.Range (-180, 180), Random.Range (-180, 180));

			GameObject a = Instantiate (asteroids[j], position, Quaternion.Euler(rotation)) as GameObject;
			float scale = Random.Range (1f, 20f);
			a.transform.localScale = new Vector3 (scale, scale, scale);
			a.transform.parent = this.transform;
		}
	}
}