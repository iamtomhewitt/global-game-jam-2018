using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public AudioSource playerBulletAudio;
	public AudioSource enemyBulletAudio;
	public bool isPlayerBullet;

	void Start()
	{
		if (isPlayerBullet)
			AudioSource.PlayClipAtPoint (playerBulletAudio.clip, transform.position);
		else
			AudioSource.PlayClipAtPoint (enemyBulletAudio.clip, transform.position);

		Destroy (this.gameObject, 5f);
	}

	void OnTriggerEnter(Collider other)
	{
		switch (other.tag) 
		{
		case "Data Upload Area":
			return;

		case "Bullet":
			return;

		case "Enemy":
			other.GetComponent<EnemyHealth> ().DecreaseHealth (15, false);
			Destroy (this.gameObject);
			break;

		case "Player":
			other.GetComponent<PlayerHealth> ().DecreaseHealth (2);
			other.GetComponent<PlayerHUD> ().UpdateHealthText (other.GetComponent<PlayerHealth> ().health.ToString());
			Destroy (this.gameObject);
			break;
		}
	}
}
