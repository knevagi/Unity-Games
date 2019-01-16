using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public UIManager ui;
	public int maxscore;
	public enum score{
		Aiscore,Playerscore
	}
	public Text aiscoretext,playerscoretext;
	private int aiscore,playerscore;

	private int Aiscore{
		get{ return aiscore;}
		set{
			aiscore = value;
			if (value == maxscore) {
				ui.showrestartcanvas (true);
			}

		}
	}

	private int Playerscore{
		get{ return playerscore;}
		set{
			playerscore = value;
			if (value == maxscore) {
				ui.showrestartcanvas (false);
			}
		}
	}
	public void increment(score whichscore){
		if (whichscore == score.Aiscore) {
		aiscoretext.text = (++Aiscore).ToString ();

		}
		else {
			playerscoretext.text = (++Playerscore).ToString ();
		}
	}

	public void resetscores(){
		Aiscore = Playerscore = 0;
		aiscoretext.text=playerscoretext.text="0";
	}

}
