using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public AsteroidSpawner asteroidSpawner;
	public DataPodSpawner dataPodSpawner;
	public EnemySpawner enemySpawner;
	public GameTimer gameTimer;
	public float gameTime;

	void Start()
	{
		asteroidSpawner.SpawnAsteroids ();
		dataPodSpawner.SpawnDataPods ();
		enemySpawner.SpawnEnemies ();
		gameTimer.StartGameTimer (gameTime);
	}

	public void TriggerGameOver()
	{
		Camera.main.transform.parent = null;
		enemySpawner.StopSpawningEnemies ();
		enemySpawner.DestroyAllEnemies ();
	}
}
