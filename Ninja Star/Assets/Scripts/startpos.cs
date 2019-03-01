using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startpos : MonoBehaviour {
	public GameObject THESOUL;
	// Use this for initialization
	void Start () {
		GameObject sl = Instantiate(THESOUL, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
