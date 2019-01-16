using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorekeeper : MonoBehaviour {

	public static int score=0;
	private Text mytext;

	void Start(){
		mytext = GetComponent<Text> ();
	}
	public void Score(int points){
		score += points;
		mytext.text = score.ToString ();
	}

	public static void Reset(){
		score = 0;
	}
	public void reset(){
		mytext.text="0";
	}

}
