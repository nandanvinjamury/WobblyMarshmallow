using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
			userPressedR ();
	}
	public void userPressedR(){
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
