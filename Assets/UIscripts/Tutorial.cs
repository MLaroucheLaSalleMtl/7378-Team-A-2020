﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject TutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        GameIsPause = true;
        TutorialPanel.SetActive(true);
    }


    public void Continue()
    {
        GameIsPause = false;
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        TutorialPanel.SetActive(false);
    }
    public void onContinue(InputAction.CallbackContext context)
    {
        Continue();
    }
}
