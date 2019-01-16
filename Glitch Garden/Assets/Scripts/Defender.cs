using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
	StarDisplay SD;
	public int StarCost=10;
	// Use this for initialization
	void Start () {
		SD = GameObject.FindObjectOfType<StarDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddStars(int amount){
		SD.AddStars (amount);
	}
}
