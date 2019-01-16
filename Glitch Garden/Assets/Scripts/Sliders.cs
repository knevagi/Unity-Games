using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Sliders : MonoBehaviour {
	private Slider slider;
	public int LevelSEconds;
	private AudioSource AS;
	private bool IsEndOfLevel=false;
	private MenuManager MM;
	private GameObject WinLabel;
	private GameObject AttackersQuit;
	private GameObject DefendersQuit;
	private GameObject PlayPanel;


	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		AS = GetComponent<AudioSource> ();
		PlayPanel = GameObject.Find ("Panel");
		MM = GameObject.FindObjectOfType<MenuManager> ();
		WinLabel = GameObject.Find ("You Win");
		WinLabel.SetActive (false);
		if (!WinLabel) {
			print ("Make a win text");
		}
		DefendersQuit = GameObject.Find ("Defenders");
		AttackersQuit = GameObject.Find ("EnemySpawner");

	}
	
	// Update is called once per frame
	void Update () {
		slider.value =  Time.timeSinceLevelLoad / LevelSEconds;
		if (Time.timeSinceLevelLoad >= LevelSEconds&&!IsEndOfLevel) {
			AS.Play ();
			WinLabel.SetActive (true);
			PlayPanel.SetActive (false);
			if (DefendersQuit) {
				DefendersQuit.SetActive (false);
			}
			AttackersQuit.SetActive (false);
			Invoke ("LoadNextLevel", AS.clip.length);
			IsEndOfLevel = true;
		}
	}
	void LoadNextLevel(){
		MM.loadnextlevel ();
	}
}
