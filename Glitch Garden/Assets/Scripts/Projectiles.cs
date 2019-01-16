using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {
	private float speed=10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Attacker") {
			Destroy (gameObject);
		}
	}
}
