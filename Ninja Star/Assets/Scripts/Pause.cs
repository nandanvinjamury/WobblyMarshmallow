using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Pause : MonoBehaviour {
    public GameObject pausePanel;
	static bool isPaused = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(!isPaused){
				isPaused = true;
				pausePanel.SetActive (true);
				Time.timeScale = 0;
			} 
			else{
				Resume();
			}
		}	
	}
	public void Resume(){
		isPaused = false;
		pausePanel.SetActive (false);
		Time.timeScale = 1;
	}
	public void ResumeFromMainMenu(){
		//pausePanel.SetActive (false);
		Time.timeScale = 1;
	}
	public void setPanelOff(){
		pausePanel.SetActive (false);
	}
	public void ChangeScene(string sceneName){
		pausePanel.SetActive (false);
		SceneManager.LoadScene (sceneName);
	}
	//Exits game
	public void ExitGameBtn(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
	public void Reload(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		Time.timeScale = 1;
	}
}

