using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	/*bool canmove=true;
	bool wasclicked=true;*/
	Vector2 playersize;
	Rigidbody2D rb;
	public Transform boundaryholder;
	Vector2 startingposition;
	public Collider2D playercollider;
	boundary playerboundary;

	public playercontroller controller;
	public int? lockedfingerid{ get; set;}
	public struct boundary{
		public float Up,Down,Left,Right;
		public boundary(float up,float down,float left,float right){
			Up=up;Down=down;Left=left;Right=right;
		}
	}

	// Use this for initialization
	void Start () {
		playersize = GetComponent<SpriteRenderer> ().bounds.extents;
		rb = GetComponent<Rigidbody2D> ();
		startingposition=rb.position;
		playerboundary = new boundary (boundaryholder.GetChild (0).position.y,
			boundaryholder.GetChild (1).position.y,
			boundaryholder.GetChild (2).position.x, boundaryholder.GetChild (3).position.x);
	}
	
	// Update is called once per frame
	/*void Update () {
		if(Input.GetMouseButton(0))
		{
			Vector2 mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (wasclicked) {
				wasclicked = false;
				if (mousepos.x >= transform.position.x && mousepos.x < transform.position.x + playersize.x || mousepos.x <= transform.position.x && mousepos.x > transform.position.x - playersize.x || mousepos.y >= transform.position.y && mousepos.y < transform.position.y + playersize.y || mousepos.x <= transform.position.y && mousepos.y > transform.position.y - playersize.y) {
					canmove = true;

				} else {
					canmove = false;
				}
				if (canmove) {
					Vector2 clampedmouse = new Vector2 (Mathf.Clamp (mousepos.x, playerboundary.Left, playerboundary.Right), Mathf.Clamp (mousepos.y, playerboundary.Down, playerboundary.Up));
					rb.MovePosition (clampedmouse);
				}
			}else {
					wasclicked = true;
				}
			}
		
	}*/
	public void movetoposition(Vector2 position){
		Vector2 clampedmouse = new Vector2 (Mathf.Clamp (position.x, playerboundary.Left, playerboundary.Right), Mathf.Clamp (position.y, playerboundary.Down, playerboundary.Up));
		rb.MovePosition (clampedmouse);
	}

	void OnEnable(){
		controller.players.Add (this);
	}
	void OnDisable(){
		controller.players.Remove (this);
	}
	public void resetposition(){
		rb.position = startingposition;
	}
}
