using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class PauseForBossScene : MonoBehaviour
{
    public GameObject PauseUI;
    public static bool GameIsPause = false;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseInGame();
        }
    }

    public void PauseInGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        player.GetComponent<ThirdPersonUserControl>().enabled = false;
    }

    public void ResumeGame()
    {
        PauseUI.SetActive(false);
        GameIsPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        player.GetComponent<ThirdPersonUserControl>().enabled = true;
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
