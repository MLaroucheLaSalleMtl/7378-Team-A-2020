using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private AsyncOperation async; 
    [SerializeField] private Image progressbar;
    [SerializeField] private Text txtPercent;

    [SerializeField] private bool waitForUserInput = false;
    private bool ready = false;
    [SerializeField] private float delay = 8; 
    [SerializeField] private int sceneToLoad = 3;  
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;   // reset the time scale to 1
        Input.ResetInputAxes(); // reset the input for 1 frame
        System.GC.Collect();     // to clean the garbage in the game
        Scene currentScene = SceneManager.GetActiveScene();  // return the current scene


        if (waitForUserInput == false)
        {
            Invoke("Activate", delay); // wait until the dalay is done then call function activite
            ready = true;
        }

        if (sceneToLoad == -1)
        {
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1); // To load the next scene
        }
        else
        {
            async = SceneManager.LoadSceneAsync(sceneToLoad);
        }

    }

    public void Activate()
    {
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForUserInput == true && Input.anyKey)
        {
            ready = true;
        }

        if (progressbar)
        {
            progressbar.fillAmount = async.progress + 0.1f; // fill the right amount

        }
        if (txtPercent)
        {
            txtPercent.text = ((async.progress + 0.1f) * 100).ToString("f2") + "%";
        }

        if (async.progress >= 0.89f && SplashScreen.isFinished && ready)
        {
            async.allowSceneActivation = true;
        }


    }
}
