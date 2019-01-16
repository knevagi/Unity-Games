﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		anim.SetBool ("IsAttacking", true);
	}
	void OnTriggerExit2D(Collider2D col){
		anim.SetBool ("IsAttacking", false);
	}

}