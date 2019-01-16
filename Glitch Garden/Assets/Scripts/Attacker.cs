using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	public float seenEverySeconds;
	public float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;
	private EnemyTrigger ET;



	int NoOfHits=0;


	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("IsAttacking", false);
		}

	}

	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}

	// Called from the animator at time of actual blow
	public void  StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}



	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Projectile") {
			NoOfHits++;
			if(NoOfHits==3){
				Destroy (gameObject);
				ET.x = false;

			}
		}
	}
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}