using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	private void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag.Equals("Finish")) {
			Destroy(collision.gameObject);
		}
	}
}
