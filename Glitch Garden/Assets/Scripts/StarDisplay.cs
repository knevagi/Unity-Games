using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

	private int stars=100;
	private Text StarsText;
	public enum status{SUCCESS,FAILURE};
	// Use this for initialization
	void Start () {
		StarsText = GetComponent<Text> ();
		UpdateDisplay ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddStars(int amount){
		stars += amount;
		UpdateDisplay ();
	}
	public status UseStars(int amount){
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return status.SUCCESS;

		} else {
			return status.FAILURE;
		}
	}
	void UpdateDisplay(){
		StarsText.text = stars.ToString ();
	}
}
