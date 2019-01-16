using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float height=5f;
	public float width=10f;
	private bool movingright = true;
	private float xmax;
	private float xmin;
	public float speed=5f;
	public float spawnDelay = 0.5f;
	GameObject enemy;
	// Use this for initialization
	void Start () {
		float distancetocamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftedge=Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distancetocamera));
		Vector3 rightedge=Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distancetocamera));
		xmax = rightedge.x;
		xmin = leftedge.x;
		SpawnUntilFull();
	}

	public void SpawnEnemies(){
			foreach (Transform child in transform) {
				enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
				enemy.transform.parent = child;
			}
		
	}

	public void SpawnUntilFull(){
		Transform freepos = nextfreeposition ();
		if (freepos) {
			GameObject enemy = Instantiate (enemyPrefab, freepos.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freepos;
		}
		if (nextfreeposition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if (movingright) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float rightedgeofformation = transform.position.x + (0.5f * width);
		float leftedgeofformation = transform.position.x - (0.5f * width);
		if (rightedgeofformation > xmax) {
			movingright = false;
		} else if (leftedgeofformation < xmin) {
			movingright = true;
		}
		if (allmembersdead ()) {
			Debug.Log ("Empty formation");
			SpawnUntilFull();
		}
	}

	Transform nextfreeposition(){
		foreach (Transform childPositionGameobject in transform) {
			if (childPositionGameobject.childCount == 0) {
				return childPositionGameobject;
			}
		}
		return null;
	}

	public bool allmembersdead(){
		foreach (Transform childPositionGameobject in transform) {
			if (childPositionGameobject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
	public void resetpos(){
		Debug.Log ("resetpos");
		Destroy (enemy);
		SpawnEnemies ();
	}

}
