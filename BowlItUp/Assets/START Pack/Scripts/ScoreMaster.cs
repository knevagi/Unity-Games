﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster : MonoBehaviour {
	public static List<int> ScoreCumulative(List<int>rolls){
		List<int> cumulativeScores = new List<int> ();
		int runningtotal = 0;
		foreach(int frameScore in ScoreFrames(rolls))
		{
			runningtotal+=frameScore;
			cumulativeScores.Add (runningtotal);
		}
		return cumulativeScores;
			
	}
	public static List<int> ScoreFrames(List<int>rolls){
		List<int> frameList = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {

			if (frameList.Count == 10) {
				break;
			}

			if (rolls [i - 1] + rolls [i] < 10) {
				frameList.Add (rolls [i - 1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) {
				break;
			}

			if (rolls [i - 1] == 10) {
				i--;
				frameList.Add (10 + rolls [i + 1] + rolls [i + 2]);
			}

			else if (rolls [i - 1] + rolls [i] == 10) {
				frameList.Add (10 + rolls [i+1]);
			}
		}

		return frameList;


}
}
