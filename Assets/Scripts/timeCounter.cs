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

    AudioSource bell_sound;
    
    void Awake()
    {
        roundTime = roundLength;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //timeText.text = roundTime.ToString("F0") + " s";
        timeText.text = minutes.ToString("F0") + ":" + seconds.ToString("F0");
        bell_sound = GameObject.Find("BellSound").GetComponent<AudioSource>();
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
            bell_sound.Play();
            GameOverUI.SetActive(true);
        }
    }
}
