using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
	public int health = 100;
	public GameObject explosion;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			DecreaseHealth (200, true);
			other.GetComponent<PlayerHealth> ().DecreaseHealth (7);
		}
	}

	public void DecreaseHealth(int amount, bool crashed)
	{
		health -= amount;

		if (health <= 0) 
		{
			GameObject e = Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (e, 10f);
			Destroy (this.gameObject);

			if (!crashed) 
			{
				GameObject.FindObjectOfType<PlayerHUD> ().ShowNotification ("+5 Seconds!");
				GameObject.FindObjectOfType<GameTimer> ().IncreaseGameTime (5f);
			}
		}
	}
}
