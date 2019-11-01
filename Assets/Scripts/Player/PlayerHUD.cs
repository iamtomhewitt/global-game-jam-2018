using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour 
{
	public Text gameTimeText;
	public Text dataPodsCollectedText;
	public Text dataPodsUploadedText;
	public Text healthText;
	public Text notificationText;
	public Transform uploadBar;
	public GameObject gameHUD;
	public GameObject gameOverHUD;

	private GameTimer gameTimer;

	void Start()
	{
		gameTimer = GameObject.FindObjectOfType<GameTimer> ();
		uploadBar.localScale = new Vector3 (0f, 1f, 1f);
	}

	void Update()
	{
		gameTimeText.text = gameTimer.gameTime.ToString ("F1");
	}

	public void ShowGameOverHUD()
	{
		gameHUD.SetActive (false);
		gameOverHUD.SetActive (true);
	}

	public void ShowNotification(string message)
	{
		notificationText.text = message;
		notificationText.GetComponent<Animator> ().Play ("Notification");
	}

	public void IncreaseUploadBar(float speed)
	{
		uploadBar.localScale = new Vector3 (speed, 1f, 1f);
	}

	public void ResetUploadBar()
	{
		uploadBar.localScale = new Vector3 (0f, 1f, 1f);
	}

	public void UpdateCollectedText(string message)
	{
		dataPodsCollectedText.text = message;
	}

	public void UpdateUploadedText(string message)
	{
		dataPodsUploadedText.text = message;
	}

	public void UpdateHealthText(string message)
	{
		healthText.text = message;
	}
}
