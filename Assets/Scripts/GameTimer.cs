using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
	[HideInInspector]
	public float gameTime;
	public float dataPodCollectionTimeValue = 5f;
	public float dataPodUploadTimeValue = 10f;
	public AudioSource alarmSound;
	private bool playedAlarmSound;

	public void StartGameTimer(float seconds)
	{
		gameTime = seconds;
	}

	void Update()
	{
		gameTime -= Time.deltaTime;

		if (gameTime < 30 && !playedAlarmSound) 
		{
			GameObject.FindObjectOfType<PlayerHUD> ().ShowNotification ("30 Seconds Left!");
			alarmSound.Play ();
			playedAlarmSound = true;
		}

		if (gameTime < 0) 
		{
			print ("TIME UP GAMEOVER");
			GameObject.FindObjectOfType<PlayerHealth> ().DecreaseHealth (200);
		}
	}

	public void IncreaseGameTime(float time)
	{
		gameTime += time;
	}
}
