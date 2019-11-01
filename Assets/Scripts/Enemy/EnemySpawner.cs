using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] enemies;
	public int maxEnemies;

	public void SpawnEnemies()
	{
		InvokeRepeating ("SpawnEnemy", 0f, 5f);
	}

	public void StopSpawningEnemies()
	{
		CancelInvoke ();
	}

	public void DestroyAllEnemies()
	{
		GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag ("Enemy");

		for (int i = 0; i < currentEnemies.Length; i++) {
			currentEnemies [i].GetComponent<EnemyHealth> ().DecreaseHealth (200, true);
		}
	}

	void SpawnEnemy()
	{
		int currentEnemyCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		if (currentEnemyCount < maxEnemies) 
		{
			int i = Random.Range (0, enemies.Length);
			GameObject e = Instantiate (enemies [i], Boundary.GenerateBoundary (), Quaternion.identity) as GameObject;
			e.transform.parent = this.transform;
		}
	}
}
