using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapons : MonoBehaviour
{
	public Transform bulletSpawn;
	public GameObject bullet;
	public float fireRate;
	public float bulletForce;
	public float firingDistance;

	private bool isInvoking = false;

	void Update()
	{
		RaycastScan ();
	}

	void RaycastScan()
	{
		RaycastHit hit;

		Debug.DrawRay(bulletSpawn.position, bulletSpawn.forward * firingDistance, Color.red);

		Ray ray = new Ray(bulletSpawn.position, bulletSpawn.forward);

		if (Physics.Raycast(ray, out hit, firingDistance))
		{
			if (hit.collider.tag == "Player")
			{
				if (!isInvoking)
				{
					InvokeRepeating("Fire", Random.Range(0f, 3f), fireRate);
					isInvoking = true;
				}
			}
		}
		else
		{
			// We are not hitting anything
			isInvoking = false;
			CancelInvoke("Fire");
		}
	}

	void Fire()
	{
		GameObject b = Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		b.GetComponent<Rigidbody> ().AddForce (b.transform.forward * bulletForce, ForceMode.Impulse);
		b.GetComponent<Bullet> ().isPlayerBullet = false;
	}
}
