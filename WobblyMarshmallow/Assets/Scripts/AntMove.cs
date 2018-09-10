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
		if(transform.position.x > 17) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag.Equals("Marshmallow")) {
			gameObject.transform.localScale *= 1.1f;
			Destroy(collision.gameObject);

		}
	}
}
