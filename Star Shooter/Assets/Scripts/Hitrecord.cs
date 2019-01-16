using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitrecord : MonoBehaviour {

	public GameObject enemylaser;

	public float ProjectileSpeed=10;
	public float health = 150;
	public float frequency = 0.5f;
	public int scorevalue=150;
	private scorekeeper sk;
	public AudioClip firesound;
	public AudioClip deathsound;

	void Start(){
		sk=GameObject.Find ("Score").GetComponent<scorekeeper> ();
	}

	void Update(){
		float probability = Time.deltaTime * frequency;
		if (Random.value < probability) {
			Fire ();
		}
	}

	void Fire(){
		Vector3 startposition = transform.position + new Vector3 (0, -1, 0);
		GameObject missile=Instantiate (enemylaser, startposition, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -ProjectileSpeed, 0);
		AudioSource.PlayClipAtPoint (firesound, transform.position);
	}

	void OnTriggerEnter2D(Collider2D col){
		Projectile missile = col.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage ();
			missile.HIT ();
			if (health <= 0) {
				AudioSource.PlayClipAtPoint (deathsound, transform.position);
				Destroy (gameObject);
				sk.Score (scorevalue);
			}
		}
	}
	// Use this for initialization

}
