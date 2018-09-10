using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshmellowMovement : MonoBehaviour {
	public float Speed = 10f;
	public float AngularVelocityCoefficient;
	public float Velocity;

	private float previousX;
	// Use this for initialization
	void Start () {
		previousX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		float direction = Input.GetAxis ("Horizontal");
		if (direction != 0) {
			Velocity = direction * Speed ;
			transform.Translate (new Vector3 (Velocity* Time.deltaTime, 0f, 0f));
		} else {
			Velocity = 0;
		}

		float deltaX = transform.position.x - previousX;
		float VelocityX = deltaX * Time.deltaTime;
		float angularVelocity = AngularVelocityCoefficient * VelocityX;
		GetComponent<MarshmellowPhysics> ().child.gameObject.GetComponent<MarshmellowPhysics> ().Rotating (angularVelocity);
		//Debug.Log ("new angularVelocity " + angularVelocity);
		Debug.Log ("VelocityX " + VelocityX);

		previousX = transform.position.x;
	}
}
