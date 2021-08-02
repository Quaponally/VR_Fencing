using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ControllerSwitch : MonoBehaviour
{
    public bool RightActive = false;
    public InputActionReference RightActivate = null;
    public InputActionReference LeftActivate = null;
    public GameObject RightController;
    public GameObject LeftController;
    
    // Start is called before the first frame update
    void Start()
    {
        // add functions to controller actions
        RightActivate.action.started += context => SwitchRight();
        LeftActivate.action.started += context => SwitchLeft();

        // get current setting
        string stored_data = PlayerPrefs.GetString("RightActive");
        if(stored_data == "true")
        {
            SwitchRight();
        }
        else 
        {
            SwitchLeft();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchRight()
    {
        if(!RightActive)
        {
            //deactivate left controller
            LeftController.SetActive(false);
            // activate right
            RightController.SetActive(true);
            RightActive = true;
            PlayerPrefs.SetString("RightActive", "true");
            PlayerPrefs.Save();
        }
    }

    void SwitchLeft()
    {
        if(RightActive)
        {
            //deactivate right controller
            RightController.SetActive(false);
            // activate left
            LeftController.SetActive(true);
            RightActive = false;
            PlayerPrefs.SetString("RightActive", "false");
            PlayerPrefs.Save();
        }
    }
}
