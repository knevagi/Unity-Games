using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
	public GameObject projectile,gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner spawner;
	private EnemyTrigger ET;

	private void Fire(){
		ET = GameObject.FindObjectOfType<EnemyTrigger> ();
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent=projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}
		animator = GameObject.FindObjectOfType<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttackingInLane ()) {
			animator.SetBool ("IsAttacking", true);
		} else {
			animator.SetBool ("IsAttacking", false);
		}
	}



	bool isAttackingInLane(){
		if (ET.x == true) {
			return true;
		} else {
			return false;
		}
	}

}
