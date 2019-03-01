using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour {
	bool isDead = false;
	float timer = 2;
	GameObject player;
	GameObject playerJump;
	void Start(){
	}

	void Update(){
		timer += 1 * Time.deltaTime;
		if (isDead == true && timer >= 2) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			SoundManagerScript.PlaySound ("shock");
			player = collision.gameObject.transform.parent.gameObject;
			playerJump = collision.gameObject;
			isDead = true;
			timer = 0;
			player.GetComponent<CharacterController> ().enabled = false;
			playerJump.GetComponent<Jump> ().enabled = false;
		}
	}
}