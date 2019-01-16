using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	[Header("Canvas")]
	public GameObject canvasgame;
	public GameObject canvasrestart;
	public GameObject canvasmultiplayer;
	public GameObject canvaspause;
	[Header("CanvasRestart")]
	public GameObject wintxt;
	public GameObject losetxt;

	public GameObject playerbluewintxt;
	public GameObject playerredwintxt;
	[Header("Other")]
	public AudioManager am;
	public Goal g;
	public AImovement ai;
	public PlayerMovement pm;
	public puckscript ps;




	public void showrestartcanvas(bool aiwin)
	{
		Time.timeScale = 0;
		if (Gamevalues.ismultiplayer == false) {
			canvasgame.SetActive (false);
			canvasrestart.SetActive (true);
			if (aiwin) {
				am.playlosemusic ();
				losetxt.SetActive (true);
				wintxt.SetActive (false);
			} else {
				am.playwinmusic ();
				losetxt.SetActive (false);
				wintxt.SetActive (true);
			}
		} else {
			canvasgame.SetActive (false);
			canvasrestart.SetActive (false);
			canvasmultiplayer.SetActive (true);
			if (aiwin) {
				am.playwinmusic ();
				playerredwintxt.SetActive (true);
				playerbluewintxt.SetActive (false);
			} else {
				am.playwinmusic ();
				playerbluewintxt.SetActive (true);
				playerredwintxt.SetActive (false);
			}
		}
	}
	public void restart(){
		Time.timeScale = 1;
		canvasgame.SetActive (true);
		canvasrestart.SetActive (false);
		canvasmultiplayer.SetActive (false);
		canvaspause.SetActive (false);
		g.resetscores ();
		ps.centerpuck ();
		pm.resetposition ();
		ai.resetpositionai ();

	}
	public void mainmenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("menu");
	}

	public void pause(){
		Time.timeScale = 0;
		canvaspause.SetActive (true);
	}
	public void resume(){
		canvaspause.SetActive (false);
		Time.timeScale = 1;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
