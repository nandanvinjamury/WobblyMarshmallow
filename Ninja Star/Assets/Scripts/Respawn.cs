using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
	}
}
