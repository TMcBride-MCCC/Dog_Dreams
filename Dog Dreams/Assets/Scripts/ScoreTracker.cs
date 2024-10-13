using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreTracker : MonoBehaviour
{
    public int score;
    public TMP_Text guiScoreText;
    public TMP_Text guiHighscoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Start the game with zero score value
        score = 0;
        guiHighscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    public void addToScore(int p)
    {
        //Add the passed amount of points to the score
        score += p;
        //Call function to update the GUI
        guiScore();
    }

    public void subtractFromScore(int p)
    {
        //Subtract the amount of points from the score
        score -= p;
    }

    public int getScore()
    {
        return score;
    }

    public void guiScore()
    {
        //Update the GUI to match the new score value
        guiScoreText.text = "Score: " + score.ToString();
    }
}
