using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    float score;

    // public GameObject ScoreBoard;
    public scoreCounter ScoreCounter;
    public GameObject ScoreUI;

    void Awake()
    {
        //script = ScoreBoard.GetComponent<scoreCounter>();
        score = scoreCounter.score;
        //ScoreUI.SetActive(false);
        scoreText.text = "Score: " + score.ToString();
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
