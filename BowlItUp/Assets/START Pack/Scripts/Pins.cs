using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {

	public float threshold=3.0f;
	public float distance=0.5f;
	private Rigidbody rb;
	private float lowerdistance;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*public bool isStanding()
	{
		Vector3 RotationEuler = transform.rotation.eulerAngles;
		float tiltinX = Mathf.Abs (RotationEuler.x);
		float tiltinZ = Mathf.Abs (RotationEuler.z);
		if (tiltinX < threshold && tiltinZ < threshold) {
			return true;
		}
		else
			return false;
		
	}*/

	public bool IsStanding()
	{
		// Ignore the Y axis (twist) of the pin, only falling (X/Z) axes by splitting the
		// rotation quaternion into X,Y,Z and scaling out the Y axis (multiply by 1,0,1)
		Vector3 eulerWithoutTwist = Vector3.Scale(transform.rotation.eulerAngles, new Vector3(1, 0, 1));

		// Create a quaternion to store the rotation without the twist
		Quaternion rotationWithoutTwist = Quaternion.Euler(eulerWithoutTwist);

		// Get the angle between pin's rotation and world's "up"
		float tiltAngle = Quaternion.Angle(rotationWithoutTwist, Quaternion.identity);

		return (tiltAngle < threshold);
	}
	public void Raise(){
		if (IsStanding ()) {
			rb.useGravity = false;
			transform.Translate (new Vector3 (0, distance/2, 0)*Time.deltaTime, Space.World);
			transform.rotation = Quaternion.Euler (0f,0f,0f);
		}
	}
	public void Lower(){
		
		if (IsStanding ()) {
			
			transform.Translate (new Vector3 (0, -distance, 0)*Time.deltaTime, Space.World);
			rb.useGravity = true;



		}
	}
}
