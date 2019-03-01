using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public Sprite[] scoreArray;
	public static int score;
	private Image image;

	// Use this for initialization
	void Start () {
		score = 0;
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (score <= 9) {
			image.sprite = scoreArray[score];
		} else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
