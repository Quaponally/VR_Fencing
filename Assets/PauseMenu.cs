using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    // public ActionBasedController controller;
    public InputActionReference pauseReference = null;

    void Start()
    {
        // controller = GetComponent<ActionBasedController>();
        pauseReference.action.performed += pauseButton;
    }

    // Update is called once per frame
    void Update()
    {
        //controls.PauseMenu.m_XRIRightHand_PauseGame.performed += _ => pauseButton();
        
        //get key press
        // controller.selectAction.action.performed += test;
        
    }


    void pauseButton(InputAction.CallbackContext context)
    {
        Debug.Log("paused");
        if(isPaused)
        {
            resume();
        }
        else 
        {
            pause();
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void goToMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
