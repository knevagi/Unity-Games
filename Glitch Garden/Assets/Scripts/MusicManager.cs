using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] MusicChange;
	private AudioSource levelmusic;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start () {
		levelmusic = GetComponent<AudioSource> ();
		SceneManager.sceneLoaded += OnLevelLoaded;
	}

	void OnLevelLoaded(Scene scene,LoadSceneMode mode){
		AudioClip musicclip = MusicChange [scene.buildIndex];
		if (musicclip) {
			levelmusic.clip = musicclip;
			levelmusic.loop = true;
			levelmusic.Play();
		}
	}

	public void SetVolume(float volume){
		levelmusic.volume = volume;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
