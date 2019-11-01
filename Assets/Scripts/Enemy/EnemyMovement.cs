using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public 	float speed = 5f;
    private float turningSpeed = 20f;
	private Transform target;

	Rigidbody rb;

    void Start () 
    {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		rb = GetComponent<Rigidbody> ();
    }

    void FixedUpdate ()
    {
        MoveTowards();
    }        

    void MoveTowards()
    {
        // Move forward
		transform.position += transform.forward * speed * Time.deltaTime;

        // Look at our target
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Rotate towrds our target
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed));
    }	   
}
