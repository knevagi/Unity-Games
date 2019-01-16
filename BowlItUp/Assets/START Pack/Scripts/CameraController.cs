﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Vector3 offset;
	public GameObject target;
	// Use this for initialization
	void Start () {
		offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(target.transform.position.z<2.4)
		transform.position = target.transform.position + offset;
	}
}
