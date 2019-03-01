using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {
	AudioSource al;
	// Use this for initialization
	void Start () {
		al = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals("Marshmallow")) {
			al.Play();
			ScoreManager.score++;
			for (int i = 0; i < GameObject.FindGameObjectsWithTag("Marshmallow").Length; i++) {
				Destroy(GameObject.FindGameObjectsWithTag("Marshmallow")[i]);
			}
		}
	}
}
