using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLaunch : MonoBehaviour {
	private Vector3 dragstart,dragend;
	private float startTime,endTime;
	private BallMove bm;
	private Vector3 launchVelocity;
	private float speed=5.0f;
	// Use this for initialization
	void Start () {
		bm = GetComponent<BallMove> ();
	}

	public void MoveStart(float amount){
		if (!bm.inplay) {
			float xpos = bm.transform.position.x;
			float ypos = bm.transform.position.y;
			float zpos = Mathf.Clamp (bm.transform.position.z + amount, -2.0f, 2.0f);
			bm.transform.position = new Vector3 (xpos, ypos, zpos);
		}
	}

	public void DragStart()
	{
		if (!bm.inplay) {
			dragstart = Input.mousePosition;
			startTime = Time.time;
		}
	}
	public void ballmoveleft()
	{
		if(!bm.inplay)
		//bm.transform.Translate(new Vector3(0,0,-speed*Time.deltaTime));
			MoveStart(-speed*Time.deltaTime);
	}
	public void ballmoveright()
	{
		if(!bm.inplay)
		//bm.transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
			MoveStart(speed*Time.deltaTime);
	}
	public void DragEnd()
	{
		if (!bm.inplay) {
			dragend = Input.mousePosition;
			endTime = Time.time;
			float dragduration = endTime - startTime;
			float speedX = (dragend.x - dragstart.x) / dragduration;
			float speedZ = (dragend.z - dragstart.z) / dragduration;
			launchVelocity = new Vector3 (-speedX, 0, speedZ);
			bm.Launch (launchVelocity);
			bm.inplay = false;
		}
	}
}
