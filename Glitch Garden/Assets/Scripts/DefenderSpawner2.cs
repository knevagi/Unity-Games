using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner2 : MonoBehaviour {

	private StarDisplay SD;
	private GameObject parent;
	private Vector3 currentpos;
	// Use this for initialization
	void Start () {
		currentpos = transform.position;


		parent=GameObject.Find("Defenders");
		if (!parent) {
			parent = new GameObject ("Defenders");
		}
		SD = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		
			GameObject defender = Buttons.SelectedDefender;
			int DefenderCost = defender.GetComponent<Defender> ().StarCost;
			if (SD.UseStars (DefenderCost) == StarDisplay.status.SUCCESS) {
				GameObject newDef = Instantiate (Buttons.SelectedDefender, currentpos, Quaternion.identity) as GameObject;
				newDef.transform.parent = parent.transform;
			} else {
				Debug.Log ("Insufficient Stars");
			}
		}


}
