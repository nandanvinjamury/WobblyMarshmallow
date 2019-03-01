using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour {

	public Sprite[] livesArray;
	public static int lives;
	private Image image;

	// Use this for initialization
	void Start () {
		lives = 6;
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lives > 0) {
			image.sprite = livesArray[lives - 1];
		} else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
		}
	}
}
