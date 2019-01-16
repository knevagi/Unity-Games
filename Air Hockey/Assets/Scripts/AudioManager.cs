using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
	public AudioClip puckcollision;
	public AudioClip goal;
	public AudioClip winmusic;
	public AudioClip losemusic;
	private AudioSource source;



	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	public void playpuckcollision(){
		source.PlayOneShot (puckcollision);
	}
	public void playgoal(){
		source.PlayOneShot (goal);
	}
	public void playwinmusic(){
		source.PlayOneShot (winmusic);
	}
	public void playlosemusic(){
		source.PlayOneShot (losemusic);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
