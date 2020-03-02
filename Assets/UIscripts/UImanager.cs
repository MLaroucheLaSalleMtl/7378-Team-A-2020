using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject ExitPanel;
    public GameObject SettingPanel;
    public AudioSource ButtonClick;

    // Start is called before the first frame update
    void Start()
    {
        ButtonClick = GetComponent<AudioSource>();
    }

    public void EnterGame()
    {
        ButtonClick.Play();
        SceneManager.LoadScene("Loading");
    }

    //Exit
    public void Exit()
    {
        ButtonClick.Play();
        ExitPanel.SetActive(true);
    }

    public void ConfirmQuit()
    {
        ButtonClick.Play();
        Application.Quit();
        print("Exit");
    }
    public void ConfirmReject()
    {
        ButtonClick.Play();
        ExitPanel.SetActive(false);       
    }

    //Setting

    public void Setting()
    {
        ButtonClick.Play();
        SettingPanel.SetActive(true);
    }

    public void SettingReturn()
    {
        ButtonClick.Play();
        SettingPanel.SetActive(false);
    }

    //open setting
    public void Opensetting()
    {
        ButtonClick.Play();
        SettingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        ButtonClick.Play();
        SettingPanel.SetActive(false);
    }

    //Turtorial

    public void OpenTutorial()
    {
        ButtonClick.Play();
        SceneManager.LoadScene("Tutorial");
    }

}
