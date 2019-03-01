using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour {
	bool isDead = false;
	float timer = 5;
	GameObject player;
	GameObject playerJump;
	GameObject camera;
	void Start(){
		//player = GameObject.Find ("player");
		//playerJump = GameObject.Find ("PCPlayer");
	}

	void Update(){
		timer += 1 * Time.deltaTime;
		if (isDead == true && timer >= 5) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			SoundManagerScript.PlaySound ("pitfall");
			player = collision.gameObject.transform.parent.gameObject;
			playerJump = collision.gameObject;
			camera = GameObject.Find ("Main Camera");
			if (camera) {
				Debug.Log ("Found");
			//	camera.GetComponent<AutoCam>().enabled = false;
			}
			isDead = true;
			timer = 0;
			player.GetComponent<CharacterController> ().enabled = false;
			playerJump.GetComponent<Jump> ().enabled = false;
		}
	}
}
