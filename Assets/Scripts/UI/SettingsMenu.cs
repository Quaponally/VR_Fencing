using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public bool LungeMode;

    void Awake()
    {
        // get current setting
        LungeMode = GlobalControl.Instance.LungeMode;

        // set toggle to match

    }

    public void ToggleLungeMode()
    {
        GlobalControl.Instance.ToggleLunge();
    }
}
