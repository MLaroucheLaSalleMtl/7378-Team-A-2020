﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Town : MonoBehaviour
{
    public AudioSource TownMusic;
    public AudioSource ThemeMusic;

    public Text TownName;
    public Image TownNameBorder;

    
    // Start is called before the first frame update
    void Start()
    {
        TownMusic = GetComponent<AudioSource>();        
        TownName.canvasRenderer.SetAlpha(0.0f);
        TownNameBorder.canvasRenderer.SetAlpha(0.0f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            TownMusic.Play();
            fadeIn();
            wait();
            ThemeMusic.Stop();
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TownMusic.Stop();
            fadeOut();
            ThemeMusic.Play();
        }
          
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
    }

    void fadeOut()
    {
        TownName.CrossFadeAlpha(0, 2, false);
        TownNameBorder.CrossFadeAlpha(0, 2, false);
    }

    void fadeIn()
    {
        TownName.CrossFadeAlpha(1, 2, false);
        TownNameBorder.CrossFadeAlpha(1, 2, false);
    }
}
