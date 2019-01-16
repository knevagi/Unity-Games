using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private PinSetter ps;
	private BallMove bm;
	private List<int> bowls = new List<int> ();
	private ScoreDisplay sd;
	// Use this for initialization
	void Start () {
		ps = GameObject.FindObjectOfType<PinSetter> ();
		bm = GameObject.FindObjectOfType<BallMove> ();
		sd = GameObject.FindObjectOfType<ScoreDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Bowl(int pinfall){
		bowls.Add (pinfall);
		ActionMaster.Action nextAction = ActionMaster.NextAction (bowls);
		ps.PerformAction (nextAction);
		sd.FillRolls (bowls);
		sd.FillFrames (ScoreMaster.ScoreCumulative (bowls));
		bm.reset ();
	}
}
