using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Drag and drop connection for Hierarchy
    public GameObject pauseMenu;
    //Let the GameManager know what the guiButtonHandler is
    private GuiButtonHandler guiButtonHandler;
    //Keep track of if the game is currently paused
    //This is used to also use p to unpause the game
    private bool isPaused = false;
    //Used for tracking score
    public TMP_Text endScore;
    private ScoreTracker scoreTracker;

    private void Start()
    {
        guiButtonHandler = GetComponent<GuiButtonHandler>();
        scoreTracker = FindAnyObjectByType<ScoreTracker>();
    }

    private void Update()
    {
        pauseButtonPress();
    }
    
    public void gameOver()
    {
        Time.timeScale = 0;
        guiButtonHandler.hideResumeButtonOnDeath();
        showPauseMenu();
        showScore();
    }
    public void pauseButtonPress()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                showPauseMenu();
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }

        //Add the ability to unpause with P as well
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        showPauseMenu();
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        hidePauseMenu();
    }

    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void hidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void showScore()
    {
        if (scoreTracker.getScore() > PlayerPrefs.GetInt("Highscore"))
        {
            Debug.Log("Highscore was: " + PlayerPrefs.GetInt("Highscore"));
            PlayerPrefs.SetInt("Highscore", scoreTracker.getScore());
            Debug.Log("Highscore is now: " + PlayerPrefs.GetInt("Highscore"));
        }
        endScore.text = "Final Score: " + scoreTracker.getScore().ToString();
    }
}
