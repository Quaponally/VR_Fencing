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
        string stored_data = PlayerPrefs.GetString("lunge_enabled");

        if(stored_data == "true")
        {
            LungeMode = true;
        }
        else{
            LungeMode = false;
        }

        // set toggle to match
        LungeToggle.GetComponent<Toggle>().SetIsOnWithoutNotify(LungeMode);
        

    }

    public void ToggleLungeMode()
    {
        if (LungeMode)
        {
            LungeMode = false;
            PlayerPrefs.SetString("lunge_enabled", "false");
            PlayerPrefs.Save();
        }
        else 
        {
            LungeMode = true;
            PlayerPrefs.SetString("lunge_enabled", "true");
            PlayerPrefs.Save();
        }
    }
}
