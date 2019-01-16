using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {
	
	private Rigidbody rb;
	private AudioSource As;
	public bool inplay = false;
	private Vector3 ballstartpos;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		As = GetComponent<AudioSource> ();
		ballstartpos = transform.position;

	}


	public void Launch (Vector3 velocity)
	{
		inplay = true;
		rb.useGravity = true;
		rb.velocity = velocity;
		As.Play ();
	}
	public void reset()
	{
		transform.position = ballstartpos;
		inplay = false;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}
}
