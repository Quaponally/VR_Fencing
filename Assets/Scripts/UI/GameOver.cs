using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Text HighscoreText;
    float score;
    float highscore;

    // public GameObject ScoreBoard;
    public scoreCounter ScoreCounter;
    public GameObject ScoreUI;

    void Awake()
    {        
        score = scoreCounter.score;
        scoreText.text = "Score: " + score.ToString();

        //GlobalControl.Instance.SaveScore(score);
        //highscore = GlobalControl.Instance.highscore;
        highscore = PlayerPrefs.GetFloat("highscore", 0f);
        if(score > highscore)
        {
            HighscoreText.text = "New Highscore!"; 
            PlayerPrefs.SetFloat("highscore", score);
            PlayerPrefs.Save();
        }
        else
        {
            HighscoreText.text = "Highscore: " + highscore.ToString();
        }    
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
