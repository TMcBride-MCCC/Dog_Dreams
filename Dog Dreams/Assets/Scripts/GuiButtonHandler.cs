using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiButtonHandler : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject resumeButton;

    private void Start()
    {
        //Can only do this because the GameManager script is attached to the same object
        //as this script.
        gameManager = GetComponent<GameManager>();
    }
    public void loadGame()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1;
        gameManager.hidePauseMenu();
    }

    public void resumeGame()
    {
        gameManager.resumeGame();
    }

    public void hideResumeButtonOnDeath()
    {
        if (resumeButton != null)
        {
            resumeButton.SetActive(false);
        }
    }

    public void exitGame()
    {
        //this only works on a build
        Application.Quit();
    }

    public void displayMenu()
    {

    }
}