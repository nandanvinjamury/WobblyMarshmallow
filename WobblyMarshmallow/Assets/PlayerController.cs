using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody rb;
	Vector3 inputVector;
	public float speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move();

	}

	public void Move() {
		inputVector.x = Input.GetAxis("Horizontal");
		rb.velocity = new Vector3(inputVector.x*speed, rb.velocity.y, 0);
	}
}
