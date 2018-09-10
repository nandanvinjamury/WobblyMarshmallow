using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshmellowPhysics : MonoBehaviour {

	public float FailAngle = 10f;
	public float AngularVelocityDampen = 20f;
	public float angularVelocity = 0f;
	public float FailAngularVelocity = 20f;
	public float MarshmallowSpringForce = 10f;
	public Transform child;
	public float angularVelocityMin = 1f;

	private Rigidbody rb;

	bool broken = false;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float rotation = angularVelocity * Time.deltaTime;
		angularVelocity = angularVelocity * AngularVelocityDampen;
		transform.Rotate (new Vector3 (0f, 0f, rotation));


		float myAngle = transform.eulerAngles.z;
		if (myAngle > 180) {
			myAngle = 360 - myAngle;
		}
		if (myAngle*myAngle > FailAngle * FailAngle && !broken) {
			BreakStack ();
			//Debug.Log ("Mallow Angle " + transform.eulerAngles.z);
		}

		//straighten
//		if (angularVelocity*angularVelocity < angularVelocityMin*angularVelocityMin && !broken) {
//			float angle = transform.eulerAngles.z;
//			transform.Rotate ( new Vector3 (0, 0,  -angle * MarshmallowSpringForce * Time.deltaTime));
//			if (angle < 0) {
//
//			} else {
//
//			}
//		}

		if (child) {
			child.gameObject.GetComponent<MarshmellowPhysics> ().Rotating (angularVelocity );
		}
	}

	public void Rotating(float angularVelocity){
		if (!child)
			return;
		if (angularVelocity > 0 && this.angularVelocity < 0 || angularVelocity < 0 && this.angularVelocity > 0) { //new rotation is opposite current rotation
			//Debug.Log("opposite Rotation");
			calculateRotationMinus(-angularVelocity);
		}else if (angularVelocity * angularVelocity > FailAngularVelocity * FailAngularVelocity) { //new velocity  is greater than failure velocity
			calculateRotation(angularVelocity);
		} else {
			child.gameObject.GetComponent<MarshmellowPhysics> ().Rotating (angularVelocity);
			//Debug.Log("Nothing special");
		}


	}

	private void calculateRotation(float angularVelocity){
		float newAngularVelocity = angularVelocity - this.angularVelocity; //(this.angularVelocity - angularVelocity); //* AngularVelocityDampen;
		//Debug.Log ("newAngularVelocity " + newAngularVelocity);
		float deltaAngularVelocity = newAngularVelocity;
		transform.Rotate (new Vector3 (0f, 0f, deltaAngularVelocity* Time.deltaTime));


		angularVelocity = this.angularVelocity + deltaAngularVelocity;
		child.gameObject.GetComponent<MarshmellowPhysics> ().Rotating (angularVelocity);
		this.angularVelocity = angularVelocity;
		//Debug.Log("Velocity threshold achieved");
	}

	private void calculateRotationMinus(float angularVelocity){
		float newAngularVelocity = angularVelocity - this.angularVelocity; //(this.angularVelocity - angularVelocity); //* AngularVelocityDampen;
		//Debug.Log ("newAngularVelocity " + newAngularVelocity);
		float deltaAngularVelocity = newAngularVelocity;
		transform.Rotate (new Vector3 (0f, 0f, deltaAngularVelocity* Time.deltaTime));


		angularVelocity = this.angularVelocity + deltaAngularVelocity;
		child.gameObject.GetComponent<MarshmellowPhysics> ().Rotating (-angularVelocity);
		this.angularVelocity = -angularVelocity;
		//Debug.Log("Velocity threshold achieved");
	}
	public void AddChild(Transform newChild){
		if (!child) {
			child = newChild;
		}
	}

	public void BreakStack(){
		if (broken)
			return;
		broken = true;
		rb.constraints = RigidbodyConstraints.None;
		rb.isKinematic = false;
		//Debug.Log ("Breaking");
		transform.parent = null;
		if (!child)
			return;
		child.gameObject.GetComponent<MarshmellowPhysics> ().BreakStack ();

		GameObject stanMarsh = GameObject.FindWithTag ("StanMarsh");
		float velocity = stanMarsh.GetComponent<MarshmellowMovement> ().Velocity;
		rb.velocity = new Vector3 (velocity * 0.9f, 0, 0);
	}
}
