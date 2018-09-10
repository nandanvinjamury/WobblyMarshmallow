using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(Time.deltaTime, 0, 0));
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag.Equals("Marshmallow")) {
			Destroy(collision.gameObject);
		}
	}
}
