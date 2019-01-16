using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
	public GameObject PauseCanvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PauseGame(){
		Time.timeScale = 0;
		PauseCanvas.SetActive (true);
	}
	public void Resume(){
		PauseCanvas.SetActive (false);
		Time.timeScale = 1;

	}
	public void RESTART(){
		PauseCanvas.SetActive (false);
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
		Time.timeScale = 1;
	}


}
