using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUploadArea : MonoBehaviour 
{
	public float uploadTimer;
	public float uploadLength;
	public AudioSource uploadSound;

	private PlayerScore playerScore;
	private PlayerHUD playerHUD;
	private GameTimer gameTimer;

	void Start()
	{
		playerScore = GameObject.FindObjectOfType<PlayerScore> ();
		playerHUD = GameObject.FindObjectOfType<PlayerHUD> ();
		gameTimer = GameObject.FindObjectOfType<GameTimer> ();
	}

	void Update()
	{
		transform.Rotate (0f, 60f * Time.deltaTime, 0f);
	}

	public void StartUpload()
	{
		print ("Upload Starting!");
		StartCoroutine(Upload ());
		uploadSound.Play ();
	}

	public void StopUpload()
	{
		print ("Exited Upload Area!");
		uploadTimer = 0f;
		playerHUD.ResetUploadBar(); // reset the upload bar
		StopAllCoroutines ();
		uploadSound.Stop ();
	}

	IEnumerator Upload()
	{
		while (uploadTimer < uploadLength) 
		{
			uploadTimer += Time.deltaTime;
			playerHUD.IncreaseUploadBar (uploadTimer / uploadLength);
			yield return null;
		}

		print ("Upload Complete. Uploaded " + playerScore.dataPodsCollected + " data pods!");
		playerHUD.ResetUploadBar(); // reset the upload bar
		playerScore.dataPodsUploaded += playerScore.dataPodsCollected;
		playerHUD.UpdateCollectedText ("Collected: " + playerScore.dataPodsCollected);

		gameTimer.IncreaseGameTime (playerScore.dataPodsCollected * gameTimer.dataPodUploadTimeValue);
		playerHUD.ShowNotification ("Data Pods transmitted! +"+(playerScore.dataPodsCollected * gameTimer.dataPodUploadTimeValue).ToString()+" Seconds!");

		playerScore.dataPodsCollected = 0;
		playerHUD.UpdateUploadedText ("Uploaded: " + playerScore.dataPodsUploaded);
		playerHUD.UpdateCollectedText ("Collected: " + playerScore.dataPodsCollected);
	}
}
