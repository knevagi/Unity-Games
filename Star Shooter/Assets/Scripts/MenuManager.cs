using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

	public GameObject canvaspause;
	private scorekeeper sk1;
	private EnemySpawner es;
	//bool abc=true;
	// Use this for initialization
	void Start () {
		sk1 = GameObject.Find ("reset").GetComponent<scorekeeper> ();
		es = GameObject.Find ("allmembersdead").GetComponent<EnemySpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void play(){
		SceneManager.LoadScene("GAME");
	}
	public void quit(){
		Application.Quit ();
	}
	public void menu(){
		SceneManager.LoadScene ("Menu");
		scorekeeper.Reset ();
	}
	public void loadnextlevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}
	public void pause(){
		Time.timeScale = 0;
		canvaspause.SetActive (true);
	}
	public void resume(){
		canvaspause.SetActive (false);
		Time.timeScale = 1;
	}
	public void restart(){
		canvaspause.SetActive (false);
		Time.timeScale = 1;
		/*sk1.reset ();
		es.resetpos ();*/
		SceneManager.LoadScene ("GAME");
		scorekeeper.Reset ();

	}
	public void mainmenu(){
		SceneManager.LoadScene ("MENU");
	}

}
