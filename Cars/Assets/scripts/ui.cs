using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 

public class ui : MonoBehaviour {
	int score;
	public Text Scoretext;
	bool gameover;
	public int ip;
	public Button[] buttons;

	//bool acce;
	 public carmove c;

	void Awake(){
    		
	}

	// Use this for initialization
	void Start () {
		//ip = 10;
		score = 0;
		gameover = false;
		//ip = 0;
		InvokeRepeating ("scoreupdate", 1.0f, 0.5f);
	
		
	}
	
	// Update is called once per frame
	void Update () {
		Scoretext.text="Score:" + score;
	}
	public void play(){
		SceneManager.LoadScene ("level1");
	}
	public void middlescene(){
		SceneManager.LoadScene ("middle");
	

	}

	public void pause(){
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}

	}
	void scoreupdate()
	{
		if (gameover == false) {
			score += 1;
		}
	    
	}
	public void gameOver()
	{
		gameover = true;
		foreach (Button button in buttons) {
			button.gameObject.SetActive (true);
		}
	}
	public void menureturn()
	{
		SceneManager.LoadScene ("menu");
	}
	public void exit()
	{
		Application.Quit ();
	} 

	public void acce(){
		 //*ip = 1;
		SceneManager.LoadScene ("level1");

}
	public void touch(){
		///*ip = 0;
		SceneManager.LoadScene ("level1");

	}

}
