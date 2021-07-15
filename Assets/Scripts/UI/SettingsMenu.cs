using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public bool LungeMode;
    public GameObject LungeToggle;

    void Awake()
    {
        // get current setting
        //LungeMode = GlobalControl.Instance.LungeMode;
        Debug.Log("Pre check SM: " + LungeMode.ToString());
        Debug.Log(PlayerPrefs.GetString("lunge_enabled"));
        string stored_data = PlayerPrefs.GetString("lunge_enabled");

        if(stored_data == "true")
        {
            LungeMode = true;
        }
        else{
            LungeMode = false;
            //LungeToggle.GetComponent<Toggle>().Select();
        }

        // set toggle to match
        // changing this from code is also triggering function call to ToggleLungeMode
        LungeToggle.GetComponent<Toggle>().isOn = LungeMode;
        //LungeToggle.GetComponent<Toggle>().Invoke(true);
        Debug.Log(PlayerPrefs.GetString("lunge_enabled"));
        Debug.Log("Post check SM: " + LungeMode.ToString());

    }

    public void ToggleLungeMode()
    {
        //GlobalControl.Instance.ToggleLunge();
        if (LungeMode)
        {
            //GlobalControl.Instance.LungeMode = false;
            // write to file
            LungeMode = false;
            PlayerPrefs.SetString("lunge_enabled", "false");
            PlayerPrefs.Save();
        }
        else 
        {
            //GlobalControl.Instance.LungeMode = true;
            // write to file
            LungeMode = true;
            PlayerPrefs.SetString("lunge_enabled", "true");
            PlayerPrefs.Save();
        }
    }
}
