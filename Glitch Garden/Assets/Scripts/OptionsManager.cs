using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionsManager : MonoBehaviour {

	public Slider VSlider;
	public Slider DSlider;
	private MusicManager audiosource;

	// Use this for initialization
	void Start () {
		audiosource = GameObject.FindObjectOfType<MusicManager> ();
		VSlider.value = PlayerPrefsManager.GetMasterVolume ();
		DSlider.value = PlayerPrefsManager.GetDifficulty ();

	}

	public void SaveAndQuit(){
		PlayerPrefsManager.SetMasterVolume (VSlider.value);
		PlayerPrefsManager.SetDifficulty (DSlider.value);
		SceneManager.LoadScene("01aSTART");
		
	}

	// Update is called once per frame
	void Update () {
		audiosource.SetVolume (VSlider.value);
	}

	public void SetDefaults(){
		VSlider.value = 0.8f;
		DSlider.value = 2f;
	}
}
