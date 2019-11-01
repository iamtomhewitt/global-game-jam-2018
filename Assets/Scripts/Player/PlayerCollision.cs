using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour 
{
	public AudioSource dataPodCollectionSound;
	private PlayerHUD playerHUD;
	private PlayerScore playerScore;
	private GameTimer gameTimer;

	void Start()
	{
		playerHUD = GetComponent<PlayerHUD> ();
		playerScore = GetComponent<PlayerScore> ();
		gameTimer = GameObject.FindObjectOfType<GameTimer> ();
	}

	void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
		case "Asteroid":
			print ("Hit an Asteroid!");
			break;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		switch (other.tag) 
		{
		case "Data Upload Area":
			other.GetComponent<DataUploadArea> ().StartUpload ();
			break;

		case "Data Pod":
			DataPod pod = other.gameObject.GetComponent<DataPod> ();
			pod.MovePosition ();

			dataPodCollectionSound.Play ();

			gameTimer.IncreaseGameTime (pod.gameTimeValue);

			playerScore.dataPodsCollected++;
			playerHUD.dataPodsCollectedText.text = "Collected: " + playerScore.dataPodsCollected;				
			playerHUD.ShowNotification ("Data Pod Collected! +" + pod.gameTimeValue + " Seconds!");
			break;

		case "Asteroid":
			GetComponent<PlayerHealth> ().DecreaseHealth (100);
			break;
		}
	}

	void OnTriggerExit(Collider other)
	{
		switch (other.tag) 
		{
		case "Data Upload Area":
			other.GetComponent<DataUploadArea> ().StopUpload ();
			break;
		}
	}
}
