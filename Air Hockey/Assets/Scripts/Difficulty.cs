using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour {
	public int abc;


	public void easy(){
		abc= 10;
		SceneManager.LoadScene ("game");
	}
	public void moderate(){
		abc = 20;
		SceneManager.LoadScene ("game");

	}
	public void difficult(){
		abc = 30;
		SceneManager.LoadScene ("game");
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
