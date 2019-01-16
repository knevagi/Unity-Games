using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	private Buttons[] buttonArray;
	public static GameObject SelectedDefender;
	public GameObject defenderPrefab;
	public Text ScoreText;
	private Defender df;
	// Use this for initialization

	void Start () {
		 	buttonArray = GameObject.FindObjectsOfType<Buttons> ();
		df = GetComponent<Defender> ();
		GetScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		foreach (Buttons thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		SelectedDefender = defenderPrefab;
		print (SelectedDefender);
	}
	void GetScore(){
		ScoreText.text ="-"+df.StarCost.ToString ();
	}
}
