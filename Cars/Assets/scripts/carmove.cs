using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class carmove : MonoBehaviour {
	public float carspeed;
	Vector3 position;
    ui u;
	bool android;
	Rigidbody2D rb;
	//public inputselect i;


	void Awake()
	{
		//DontDestroyOnLoad (ui);
		rb = GetComponent<Rigidbody2D> ();
		#if UNITY_ANDROID
		android=true;
		#else
		android=false;
		#endif
	}

	// Use this for initialization
	void Start () {
		position = transform.position;

		if (android == true) {
			Debug.Log ("Android");

		}
			else{
				Debug.Log("Windows");
			
			}
		
		}
		

	
	// Update is called once per frame
	void Update () {
		if (android == false) {
			position.x += Input.GetAxis ("Horizontal") * carspeed * Time.deltaTime;

		
		} else {
			
			if (u.ip == 1) {
				accelerometer ();
			} else if (u.ip == 0) {
				touchmove ();
			}

		}

		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.2f, 2.2f);
		transform.position = position;
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Respawn") {
			Destroy (gameObject);
			u.gameOver();
		}
	}

	public void touchmove(){
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			float middle = Screen.width / 2;
			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				moveleft ();
			}
			if (touch.position.x > middle && touch.phase == TouchPhase.Began) {
				moveright ();
			}
		} else {
			setvelocityzero ();
		}

	
	}
	public void accelerometer()
	{
		float x = Input.acceleration.x;
		if (x < -0.1f) {
			moveleft ();
		} else if (x > 0.1f) {
			moveright ();
		}
	}
	public void moveleft(){
		rb.velocity = new Vector2 (-carspeed,0);
	}
	public void moveright(){
		rb.velocity = new Vector2 (carspeed, 0);
	}
	public void setvelocityzero(){
		rb.velocity = Vector2.zero;
	}
}
