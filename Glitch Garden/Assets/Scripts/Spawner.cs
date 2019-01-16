using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] Attac;
	public Vector3 SpawnPos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject ThisAttacker in Attac) {
			if(isItTime (ThisAttacker)) {
				Spawn (ThisAttacker);
			}
		}
	}
	void Spawn(GameObject Go){
		GameObject att = Instantiate (Go,SpawnPos,Quaternion.identity) as GameObject;
		att.transform.parent = transform;
		att.transform.position = transform.position;
	}
	bool isItTime (GameObject go){
		Attacker attacks = go.GetComponent<Attacker> ();
		float meanSpawnDelay = attacks.seenEverySeconds;
		float SpawnsPerSecond = 1 / meanSpawnDelay;
		if (Time.deltaTime > SpawnsPerSecond) {
			Debug.LogWarning ("Spawnrate capped by Frame rate");
		}
		float threshold = SpawnsPerSecond * Time.deltaTime / 5;
		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
		//return true;
	}


}
