using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {
	public float timetonextlevel;
	// Use this for initialization
	void Start () {
		if (timetonextlevel <= 0) {
			Debug.Log ("Use positive value");
		} else {
			Invoke ("loadnextlevel", timetonextlevel);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void loadnextlevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}
}
