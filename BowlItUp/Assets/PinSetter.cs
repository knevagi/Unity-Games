using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	

	private Animator anim;
	public GameObject pinset;
	private float child;

	private ActionMaster AM=new ActionMaster();
	private PinCounter pc;


	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();
		pc = GameObject.FindObjectOfType<PinCounter> ();
	}
	
	// Update is called once per frame
	void Update () {
		child = pinset.transform.childCount;
			print (child);
		if(pinset.transform.childCount==0)
		{
			Destroy(pinset);
		}
	
	}


	public void PerformAction(ActionMaster.Action action)
	{
		if (action == ActionMaster.Action.Tidy) {
			anim.SetTrigger ("TidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			anim.SetTrigger ("ResetTrigger");
			pc.Reset();
		}
		else if (action == ActionMaster.Action.Reset) {
			anim.SetTrigger ("ResetTrigger");
			pc.Reset();
		}
		else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Dont know how to handle");
		}
	}

	void OnTriggerExit(Collider col)
	{
		
		if (col.gameObject.tag == "Pins") {
			Destroy (col.transform.parent.gameObject);

		}
	}
	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag=="Ball") {
			pc.ballenteredbox= true;
			pc.score.color = Color.red;
		}
	}
	public void Raise()
	{
		foreach(Pins p in GameObject.FindObjectsOfType<Pins>())
		{
			p.Raise ();

		}
	}
	public void Lower()
	{
		foreach(Pins p in GameObject.FindObjectsOfType<Pins>())
		{
			p.Lower ();
		}
	}
	public void Renew()
	{
		Debug.Log ("Renewing");
		Instantiate (pinset, new Vector3 (-6.41f,14.64f, -0.1666691f), Quaternion.identity);
	}
}
