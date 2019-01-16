using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImovement : MonoBehaviour {
	public float maxmovementspeed;
	private Rigidbody2D rb;
	private Vector2 startingposition;
	public Rigidbody2D puck;

	public Transform playerboundaryholder;
	private PlayerMovement.boundary playerboundary;
	public Transform puckboundaryholder;
	private PlayerMovement.boundary puckplayerboundary;
	private Vector2 targetposition;
	private bool isfirsttime=true;
	private float offsetxfromtarget;
	float movementspeed;

	public Difficulty di;
	int value;

	public Collider2D puckcollider;
	public Collider2D wallcollider;
	public Collider2D playercollider;

	//public float abc;



	Vector3 newpos=new Vector3(-0.004499346f,-1.79f,0f);


	void Awake(){
		DontDestroyOnLoad (di);
	}



	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody2D>();
		startingposition=rb.position;
		playerboundary = new PlayerMovement.boundary (playerboundaryholder.GetChild (0).position.y,
			playerboundaryholder.GetChild (1).position.y,
			playerboundaryholder.GetChild (2).position.x, playerboundaryholder.GetChild (3).position.x);

		puckplayerboundary = new PlayerMovement.boundary (puckboundaryholder.GetChild (0).position.y,
			puckboundaryholder.GetChild (1).position.y,
			puckboundaryholder.GetChild (2).position.x, puckboundaryholder.GetChild (3).position.x);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void FixedUpdate(){

		if (di.abc == 10) {
			maxmovementspeed = 10;
		} else if (di.abc == 20) {
			maxmovementspeed = 20;
		} else if (di.abc == 30) {
			maxmovementspeed = 30;
		}
		if (puckscript.wasgoal == false) {
			if (puck.position.y > puckplayerboundary.Up) {
				if (isfirsttime) {
					isfirsttime = false;
					offsetxfromtarget = Random.Range (-1f, 1f);
				}
				movementspeed = maxmovementspeed * Random.Range (0.1f, 0.3f);

				targetposition = new Vector2 (Mathf.Clamp (puck.position.x + offsetxfromtarget, playerboundary.Left, playerboundary.Right), startingposition.y);
			} else {
				isfirsttime = true;
				movementspeed = Random.Range (maxmovementspeed * 0.4f, maxmovementspeed);
				targetposition = new Vector2 (Mathf.Clamp (puck.position.x, playerboundary.Left, playerboundary.Right), 
					Mathf.Clamp (puck.position.y, playerboundary.Down, playerboundary.Up));
				if (playercollider.IsTouching (puckcollider) && puckcollider.IsTouching (wallcollider)) {

					//abc = 10f;
					transform.Translate (-0.004499346f, -1.79f, 0f);
					//rb.MovePosition(Vector2.MoveTowards(rb.position,newpos,movementspeed*Time.fixedDeltaTime));
					rb.MovePosition (Vector2.MoveTowards (rb.position, targetposition, movementspeed * Time.fixedDeltaTime));

				}
			
			}
			rb.MovePosition (Vector2.MoveTowards (rb.position, targetposition, movementspeed * Time.fixedDeltaTime));
		}

	}
	public void resetpositionai(){
		rb.position = startingposition;
	}
}
