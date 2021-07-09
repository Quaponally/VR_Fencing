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
        GlobalControl.Instance.SaveScore();
        highscore = GlobalControl.Instance.highscore;

        
        score = scoreCounter.score;
        
        scoreText.text = "Score: " + score.ToString();
        HighscoreText.text = "Highscore: " + highscore.ToString();
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