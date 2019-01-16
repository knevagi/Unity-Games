using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puckscript : MonoBehaviour {
	public Goal abc;
	public static bool wasgoal{ get; private set; }
	private Rigidbody2D rb;
	public float maxspeed;
	public AudioManager am;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		wasgoal = false;
		
	}
	private void OnTriggerEnter2D(Collider2D other){
		if (!wasgoal) {
			if (other.tag == "Aigoal") {
				abc.increment (Goal.score.Playerscore);
				wasgoal = true;
				am.playgoal ();
				StartCoroutine (resetpuck (false));
			} else if (other.tag == "Playergoal") {
				abc.increment (Goal.score.Aiscore);
				wasgoal = true;
				am.playgoal ();
				StartCoroutine (resetpuck (true));
			}
		}
	}
	public void OnCollisionEnter2D(Collider2D col){
		am.playpuckcollision ();
	}

	private IEnumerator resetpuck(bool didaiscore){
		yield return new WaitForSecondsRealtime (0.5f);
		wasgoal = false;
		rb.velocity = rb.position = new Vector2 (0, 0);
		if (didaiscore)
			rb.position = new Vector2 (0, 1);
		else
			rb.position = new Vector2 (0, -1);
	}
	public void FixedUpdate(){
		rb.velocity = Vector2.ClampMagnitude (rb.velocity, maxspeed);
	}
	// Update is called once per frame

	public void centerpuck(){
		rb.position = new Vector2 (0, 0);
	}
	void Update () {
		
	}
}
