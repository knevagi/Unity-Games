//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public class ScoreDisplay : MonoBehaviour {
//	public Text[] RollText, FrameText;
//
//	public void FillRolls(List<int>rolls){
//		string scoreString = FormatRolls (rolls);
//		for (int i = 0; i < scoreString.Length; i++) {
//			RollText [i].text = scoreString [i].ToString();
//		}
//	}
//	public void FillFrames(List<int>frames){
//		for (int i = 0; i < frames.Count; i++) {
//			FrameText [i].text = frames [i].ToString ();
//		}
//	}
//	public static string FormatRolls(List<int>rolls){
//		string output = "";
//
//		for (int i = 0; i < rolls.Count; i++) {
//			int roll = output.Length + 1;
//			if (rolls [i] == 0) {
//				output+="-";
//			}
//			else if (((roll % 2 == 0)||(roll==21)) && (rolls [i - 1] + rolls [i] == 10)) {
//				output += "/";
//			} else if (roll >= 19 && rolls [i] == 10) {
//				output+="X";
//			}
//			else if (rolls [i] == 10) {
//				output += "X ";
//			} else {
//				output += rolls [i].ToString ();
//			}
//		}
//		return output;
//	}
//
//}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void FillRolls (List<int> rolls) {
		string scoresString = FormatRolls (rolls);
		for (int i = 0; i < scoresString.Length; i++) {
			rollTexts[i].text = scoresString[i].ToString();
		}
	}

	public void FillFrames (List<int> frames) {
		for (int i = 0; i < frames.Count; i++) {
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls (List<int> rolls) {
		string output = "";

		for (int i = 0; i < rolls.Count; i++) {
			int box = output.Length + 1;							// Score box 1 to 21 

			if (rolls[i] == 0) {									// Always enter 0 as -
				output += "-";
			} else if (box % 2 == 0 && rolls[i-1]+rolls[i] == 10) {	// SPARE anywhere
				output += "/";	
			} else if (box >= 19 && rolls[i] == 10)	{				// STRIKE in frame 10
				output += "X";
			} else if (rolls[i] == 10) {							// STRIKE in frame 1-9
				output += "X ";
			} else {
				output += rolls[i].ToString();	
				Debug.Log("Output" + output);						// Normal 1-9 bowl
			}

		}

		return output;
	}
}
