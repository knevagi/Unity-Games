using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster : MonoBehaviour {

	public enum Action {Tidy,Reset,EndTurn,EndGame};

	private int[] bowls=new int[21];
	private int bowl = 1;

	public static Action NextAction(List<int>pinfalls){
		ActionMaster am = new ActionMaster ();
		Action currentAction = new Action ();
		foreach (int pinfall in pinfalls) {
			currentAction = am.Bowl (pinfall);
		}
		return currentAction;
	}

	public Action Bowl (int pins)
	{
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invalid Pins");
		}
		bowls [bowl - 1] = pins;


		if (bowl == 21)
			return Action.EndGame;

		if (bowl >= 19 && pins == 10) {
			bowl++;
			return Action.Reset;
		} else if (bowl == 20) {
			bowl++;
			if (bowls [19 - 1] == 10 && bowls [20 - 1] == 0) {
				return Action.Tidy;
			}
			else if ((bowls [19 - 1] + bowls [20 - 1])==10) {
				return Action.Reset;
			} else if (Bowl21Awarded ()) {
				return Action.Tidy;
			} else {
				return Action.EndGame;
			}
		}

		//if (pins == 10) {
		//	bowl += 2;
		//	return Action.EndTurn;

		//}

		if (bowl % 2 != 0) {
			if (pins == 10) {
				bowl += 2;
				return Action.EndTurn;
			} else {
				bowl += 1;
				return Action.Tidy;
			}
		}
		else if (bowl % 2 == 0) {
			bowl += 1;
			return Action.EndTurn;
		}
		throw new UnityException("Notsure what action to return");
	}

	private bool Bowl21Awarded()
	{
		return(bowls [19 - 1] + bowls [20 - 1] >= 10);
	}

}
