using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour {

	private MusicManager mm;
	// Use this for initialization
	void Start () {
		mm = GameObject.FindObjectOfType<MusicManager> ();
		if (mm) {
			float volume = PlayerPrefsManager.GetMasterVolume ();
			mm.SetVolume (volume);
		} else{
			Debug.LogWarning ("Music manager not found");

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
