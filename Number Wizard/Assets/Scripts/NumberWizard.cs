using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

	int max = 1000;
	int min = 0;
	int guess=500;
	public Text text;
	int maxguesses=10;
	int noofguesses=1;


	// Use this for initialization
	void Start () {
		startgame ();
		//nextguess ();
	}
	void startgame(){
		
		max = max + 1;
		nextguess ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			guesshigher ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			guesslower ();
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene("Won");
		}
	}
	public void guesshigher(){
		min = guess;
		nextguess ();
	}
	public void guesslower(){
		max = guess;
		nextguess ();
	}
	public void win(){
		SceneManager.LoadScene ("Won");
	}
	void nextguess(){
		noofguesses++;
		guess = (max + min) / 2;
		text.text = "Is your number higher,lower or equal to " +guess.ToString ();
		if (noofguesses > maxguesses) {
			SceneManager.LoadScene ("Lose");
		}
	}
}
