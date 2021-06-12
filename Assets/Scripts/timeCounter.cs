using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCounter : MonoBehaviour
{
    public Text timeText;

    public float roundLength = 180f;
    public float roundTime; 

    // Start is called before the first frame update
    void Start()
    {
        roundTime = roundLength;
        timeText.text = roundTime.ToString() + " s";
    }

    // Update is called once per frame
    void Update()
    {
        roundTime -= Time.deltaTime;
        timeText.text = roundTime.ToString() + " s";
    }
}
