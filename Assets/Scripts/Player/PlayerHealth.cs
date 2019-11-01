using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	public int health = 100;
	public GameObject explosion;
	public AudioSource hitSound;

	public void DecreaseHealth(int amount)
	{
		health -= amount;
		GetComponent<PlayerHUD> ().UpdateHealthText (health.ToString ());
		hitSound.Play ();

		if (health <= 0) 
		{
			GameObject.FindObjectOfType<GameManager> ().TriggerGameOver ();
			Instantiate (explosion, transform.position, Quaternion.identity);
			GetComponent<PlayerHUD> ().ShowGameOverHUD ();
			Destroy (this.gameObject);
		}
	}
}
