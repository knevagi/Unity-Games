using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	static AudioManager instance = null;

	public AudioClip startclip;
	public AudioClip gameclip;
	public AudioClip endclip;

	private AudioSource music;

	void Awake(){
		if (instance != null&&instance!=this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			music = GetComponent<AudioSource> ();
			music.clip = startclip;
			music.loop = true;
			music.Play ();
		}
	}

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnLevelWasLoaded (int level){
		Debug.Log("Music player loaded");
		music.Stop ();
		if (level == 0) {
			music.clip = startclip;
		}
		if (level == 1) {
			music.clip = gameclip;
		}
		if (level == 2) {
			music.clip = endclip;
		}
		music.loop = true;
		music.Play ();
	}
}
