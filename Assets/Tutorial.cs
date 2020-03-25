using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        GameIsPause = false;
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        TutorialPanel.SetActive(false);
    }
}
