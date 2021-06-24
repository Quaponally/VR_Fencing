using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class timeCounter : MonoBehaviour
{
    public Text timeText;

    public float roundLength = 180f;
    public float roundTime; 

    private float minutes = 3f;
    private float seconds = 0f;

    public GameObject GameOverUI;
    

    // Start is called before the first frame update
    void Start()
    {
        roundTime = roundLength;
        //timeText.text = roundTime.ToString("F0") + " s";
        timeText.text = minutes.ToString("F0") + ":" + seconds.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        roundTime -= Time.deltaTime;
        minutes = roundTime/60f;
        seconds = roundTime % 60f; 
        
        timeText.text = Math.Floor(minutes).ToString("F0") + ":" + ((int)seconds).ToString("D2");

        if(roundTime <= 0f)
        {
            
            GameOverUI.SetActive(true);
        }
    }
}
