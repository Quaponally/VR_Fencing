using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    // saved variables
    public float score;
    public float highscore = 0.0f;
    public bool LungeMode = true;

    
    // setup
    public static GlobalControl Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy (gameObject);
        }

        // read player data file

        // assign any variables 
    }

    public void SaveScore(float score)
    {
        GlobalControl.Instance.score = score;
        if(score > highscore)
        {
            GlobalControl.Instance.highscore = score;
            // write to file
        }
    }

    public void ToggleLunge()
    {
        if (LungeMode)
        {
            GlobalControl.Instance.LungeMode = false;
            // write to file
        }
        else 
        {
            GlobalControl.Instance.LungeMode = true;
            // write to file
        }
    }
}
