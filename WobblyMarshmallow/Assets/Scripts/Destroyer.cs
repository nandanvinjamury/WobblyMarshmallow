using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	AudioSource al;

	private void Start() {
		al = GetComponent<AudioSource>();
	}

	private void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag.Equals("Marshmallow") || collision.gameObject.tag.Equals("Ant")) {
			al.Play();
			LivesManager.lives--;
			Destroy(collision.gameObject);
		}
	}
}
