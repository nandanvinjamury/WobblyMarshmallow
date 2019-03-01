using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject failMenuUI;
    public GameObject startOfLevel;
    public PlayerController player;

    public int NumOfMinions;
    public int NumOfMinionFinished;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        //determines if the game is paused or not.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Method that continues the game.
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //sets the speed of time to normal (rather than being frozen).
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Method that pauses the game and brings up a pause menu.
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        //freezes time.
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Fail()
    {
        failMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Method that changes the level (used in the level menu when the game is paused).
    public void ChangeLevel(int levelNumber)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelNumber);
    }

    public static void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void winCondition(Collision2D collision)
    {

        //if (MinionCount.levelFinished())
        //{
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
 
    }
}
