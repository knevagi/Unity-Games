using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menumanager : MonoBehaviour {

	public Toggle multiplayertoggle;

	void Start(){
		multiplayertoggle.isOn = Gamevalues.ismultiplayer;
	}
	public void playgame(){
		if (multiplayertoggle.isOn == true) {
			SceneManager.LoadScene ("game");
		} else {
			SceneManager.LoadScene ("difficulty");
		}
	}
	public void SetMultiplayer(bool isOn){
		Gamevalues.ismultiplayer = isOn;
	}
	public void exit(){
		Application.Quit();
	}
}
