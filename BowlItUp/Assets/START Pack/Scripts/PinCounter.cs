using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
	public Text score;
	public bool ballenteredbox=false;
	private float laststandingtime = 0;
	private float laststandingcount=-1;
	private int lastsettledcount=10;
	private BallMove ball;
	private GameManager gm;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<BallMove> ();
		gm = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = CountStanding ().ToString();
		if (ballenteredbox) {
			checkstanding ();
		}
	}
	void checkstanding()
	{
		float currentstanding = CountStanding ();
		if (currentstanding != laststandingcount) {
			laststandingtime = Time.time;
			laststandingcount = currentstanding;
			return;
		}
		float settletime = 3f;
		if ((Time.time - laststandingtime) > settletime) {
			Pinsettle ();
		}
	}
	void Pinsettle()
	{
		int pinfall = lastsettledcount - CountStanding ();
		lastsettledcount = CountStanding ();


		gm.Bowl (pinfall);
		//ball.reset ();
		laststandingcount = -1;
		ballenteredbox = false;
		score.color = Color.green;
	}
	public void Reset(){
		lastsettledcount = 10;
	}



	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name == "Bowling ball") {
			ballenteredbox = true;
		}
	}

	int CountStanding()
	{
		int count=0;
		foreach(Pins p in GameObject.FindObjectsOfType<Pins>())
		{
			if (p.IsStanding ()) {
				count++;
			}
		}
		return count;
	}
}
