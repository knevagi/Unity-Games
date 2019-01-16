using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawn : MonoBehaviour {
	public GameObject[] cars;
	int carno;
	public float maxpos=2.2f;
	public float delaytimer=1f;
	float timer;

	// Use this for initialization
	void Start () {
		timer = delaytimer;
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 carpos = new Vector3 (Random.Range (-2.2f, 2.2f), transform.position.y, transform.position.z);
			carno = Random.Range (0, 3);
			Instantiate (cars[carno], carpos, transform.rotation);
			timer = delaytimer;
		}
		
	}
}
