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
    AudioSource en_garde;
    AudioSource pret;
    AudioSource alle;

    public bool start = true;
    //bool played_en_garde = false;
    bool played_pret = false;
    bool played_alle = false;
    float start_timer = 3f;
    bool round_over = false;

    
    void Awake()
    {
        en_garde = GameObject.Find("en garde").GetComponent<AudioSource>();
        pret = GameObject.Find("pret").GetComponent<AudioSource>();
        alle = GameObject.Find("alle").GetComponent<AudioSource>();

        en_garde.Play();
        //played_en_garde = true;

        // set clock timer
        roundTime = roundLength;
        minutes = roundTime/60f;
        seconds = roundTime % 60f;
        timeText.text = Math.Floor(minutes).ToString("F0") + ":" + ((int)seconds).ToString("D2");
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //timeText.text = roundTime.ToString("F0") + " s";
        //timeText.text = minutes.ToString("F0") + ":" + seconds.ToString("F0");
        bell_sound = GameObject.Find("BellSound").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // normal timer calculation and UI update
        if(!start)
        {
            roundTime -= Time.deltaTime;
            minutes = roundTime/60f;
            seconds = roundTime % 60f; 

            if(roundTime < 0f && !round_over)
            {
                bell_sound.Play();
                GameOverUI.SetActive(true);
                round_over = true;
            }
            else if(roundTime > 0f)
            {
                timeText.text = Math.Floor(minutes).ToString("F0") + ":" + ((int)seconds).ToString("D2");
            }
        }
        // play sounds during start sequence
        else
        {
            start_timer -= Time.deltaTime;
            if(start_timer <= 0f && !played_alle) 
            {
                alle.Play();
                start = false;
                played_alle = true;
            }
            else if(start_timer <= 1f && !played_pret)
            {
                pret.Play();
                played_pret = true;
            }
        }
    }
}
