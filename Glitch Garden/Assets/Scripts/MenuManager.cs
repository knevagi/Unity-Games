﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {


	//public float timetonextlevel;
	// Use this for initialization
	void Start () {
		/*if (timetonextlevel <= 0) {
			Debug.Log ("Use positive value");
		} else {
			Invoke ("loadnextlevel", timetonextlevel);
		}*/

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void play(){
		SceneManager.LoadScene("02aLevel1");
	}
	public void quit(){
		Application.Quit ();
	}
	public void menu(){
		SceneManager.LoadScene ("01aSTART");
	}
	public void options(){
		SceneManager.LoadScene ("01bOptions");
	}
	public void WinScreen(){
		SceneManager.LoadScene ("03aWin");
	}
	public void LoseScreen(){
		SceneManager.LoadScene ("03bLose");
	}
	public void loadnextlevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}


}