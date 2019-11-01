using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour 
{
	public Transform cannon;
	public Transform bulletSpawn;
	public GameObject bullet;
	public float rotationSpeed = 2f;
	public float bulletForce;
	public float fireRate;
	private float cooldown;

	void Start()
	{
		cooldown = fireRate;
	}

	void Update()
	{
		cooldown -= Time.deltaTime;

		RotateTowardsCameraDirection ();

		if (Input.GetButton ("Fire1") && cooldown <= 0)
		{
			cooldown = fireRate;
			Fire ();
		}
	}

	void Fire()
	{
		GameObject b = Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		Physics.IgnoreCollision (GetComponent<Collider> (), b.GetComponent<Collider> ());
		b.GetComponent<Rigidbody> ().AddForce (b.transform.forward * bulletForce, ForceMode.Impulse);
		b.GetComponent<Bullet> ().isPlayerBullet = true;
	}

	void RotateTowardsCameraDirection()
	{
		float x = Screen.width / 2f;
		float y = Screen.height / 2f;

		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (x, y, 0f));
		Quaternion look = Quaternion.LookRotation (ray.direction);
		cannon.rotation = Quaternion.Slerp(cannon.rotation, look, Time.deltaTime * rotationSpeed);
	}
}
