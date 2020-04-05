using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(Slider))]
public class GameControl : MonoBehaviour
{
    public GameObject PauseUI;
    public static bool GameIsPause = false;
   
    public GameObject player;
    
    [SerializeField] private Transform ResPoint;
    [SerializeField] private Transform Deadplayer;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseInGame();
            //lastPressed++;
            //if (lastPressed > 1)
            //{
            //    ResumeGame();
            //    lastPressed = 0;
            //}
        }

        
    }

    void PauseInGame()
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

    public void GoReturn()
    {
        
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        player.GetComponent<ThirdPersonUserControl>().enabled = true;
    }

    public void ReturnToLobby()
    {
          
        SceneManager.LoadScene("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
}
