using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void changeScore(int delta){
        score += delta;
    }
}
