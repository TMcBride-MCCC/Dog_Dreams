using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Drag and drop connection for Hierarchy
    public GameObject pauseMenu;

    private void Update()
    {
        pauseButtonPress();
    }
    public void pauseButtonPress()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            showPauseMenu();
            pauseGame();
        }

        //Add the ability to unpause with P as well
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
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
}
