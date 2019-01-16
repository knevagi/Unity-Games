using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {

	public List<PlayerMovement>players= new List<PlayerMovement>();
	public GameObject aiplayer;

	private void Start(){
		if (Gamevalues.ismultiplayer) {
			aiplayer.GetComponent<PlayerMovement> ().enabled = true;
			aiplayer.GetComponent<AImovement> ().enabled = false;
		} else {
			aiplayer.GetComponent<PlayerMovement> ().enabled = false;
			aiplayer.GetComponent<AImovement> ().enabled = true;
		}
	}
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
			Vector2 touchworldpos = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position);
			foreach (var player in players) {
				if (player.lockedfingerid == null) {
					if (Input.GetTouch (i).phase == TouchPhase.Began && player.playercollider.OverlapPoint (touchworldpos)) {
						player.lockedfingerid = Input.GetTouch (i).fingerId;
					}
				} else if(player.lockedfingerid==Input.GetTouch(i).fingerId) {
					player.movetoposition (touchworldpos);
					if (Input.GetTouch (i).phase == TouchPhase.Ended || Input.GetTouch (i).phase == TouchPhase.Canceled) {
						
						player.lockedfingerid = null;
					}
				}

		}
	}
	}
}

