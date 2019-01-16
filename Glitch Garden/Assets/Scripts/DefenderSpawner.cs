using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;
	private GameObject parent;
	private StarDisplay SD;
	// Use this for initialization
	void Start () {
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
		Vector2 Rawpos = CalculateWorldPointOfClick ();
		Vector2 roundedpos = SnapToGrid (Rawpos);
		GameObject defender = Buttons.SelectedDefender;
		int DefenderCost =defender.GetComponent<Defender> ().StarCost;
		if (SD.UseStars(DefenderCost)==StarDisplay.status.SUCCESS) {
			GameObject newDef = Instantiate (Buttons.SelectedDefender, roundedpos, Quaternion.identity) as GameObject;
			newDef.transform.parent = parent.transform;
		} else {
			Debug.Log ("Insufficient Stars");
		}
	}


	Vector2 SnapToGrid(Vector2 RawWorldPos){
		float newX = /*Mathf.RoundToInt (RawWorldPos.x);*/closestNumber (RawWorldPos.x, 2.4f);
		float newY = Mathf.RoundToInt (RawWorldPos.y);
		return new Vector2 (newX, newY);
	}
	float closestNumber(float n,float m){
		float q = n / m;
		float n1 = m * q;
		float n2 = (n * m) > 0 ? (m * (q + 1)) : (m * (q - 1));

		if (Mathf.Abs (n - n1) < Mathf.Abs (n - n2))
			return n1;
		return n2;
	}




	Vector3 CalculateWorldPointOfClick (){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distancetoCamera = 10f;
		Vector3 position = new Vector3 (mouseX, mouseY, distancetoCamera);
		Vector2 Worldpos = myCamera.ScreenToWorldPoint (position);
		return Worldpos;
	}
}
