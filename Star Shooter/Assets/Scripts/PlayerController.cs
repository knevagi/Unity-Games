using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float speed=5.0f;
	public float padding=1f;
	float xmin;
	float xmax;
	public GameObject projectile;
	public float projectilespeed=5f;
	public float firingrate=0.2f;

	public float health = 150;

	public AudioClip firesound;



	void Awake(){
		
	}
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x+padding;
		xmax = rightmost.x-padding;
	}

	void fire(){
		Vector3 offset = new Vector3 (0, 1, 0);
		GameObject beam =Instantiate(projectile,transform.position+offset,Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0,projectilespeed,0);
		AudioSource.PlayClipAtPoint (firesound, transform.position);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating ("fire", 0.000001f, firingrate);

		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ();
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if (Input.GetKey (KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX,transform.position.y,transform.position.z);
	}
	void OnTriggerEnter2D(Collider2D col){
		Projectile missile = col.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage();
			missile.HIT ();
			if (health <= 0) {
				//UI man = GameObject.Find ("UI").GetComponent<UI> ();
				SceneManager.LoadScene ("Win screen");
				Destroy (gameObject);
			}
		}
	}

}
