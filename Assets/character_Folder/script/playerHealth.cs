﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class playerHealth : MonoBehaviour
{
    public float health = 100f;
   

    private Animator anim;
    public Image hpImg;
    public static playerHealth instance;

    //To open the dead UI Panel
    public GameObject DeadPanel;
    public AudioSource DeadMusic;
    public Image DeadBackground;
    public Text DeadText;
    public Text DeadHint;
    public GameObject player;

    public GameObject FirstPanel;
    public GameObject SecondPanel;
    public GameObject ThridPanel;

   
    public AudioSource LivesAdd;
    public int CountNum = 0;
    public GameObject PointerForBoss;
    public GameObject BossPanel;
    public GameObject Pointer;
    public GameObject BossDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
        DeadMusic = GetComponent<AudioSource>();
        
        DeadBackground.canvasRenderer.SetAlpha(0.0f);
        DeadHint.canvasRenderer.SetAlpha(0.0f);
        DeadText.canvasRenderer.SetAlpha(0.0f);

        LivesAdd = GetComponent<AudioSource>();
        
    }

    public void takeDamage(float damage)
    {

        health -= damage;
        hpImg.fillAmount = health / 100;
        if(health <= 0)
        {
            health = 0;
            anim.SetBool("Die", true);

            //To show the dead panel
            DeadPanel.SetActive(true);
            DeadMusic.Play();
            fadeIn();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
           
            //To stop other music
            GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Stop();
            GameObject.Find("Trigger for Badger").GetComponent<Badger>().AttackMusic.Stop();
            GameObject.Find("Trigger for Ant").GetComponent<Ant>().AttackMusic.Stop();
            GameObject.Find("Trigger For Eagle").GetComponent<Eagle>().AttackMusic.Stop();
            //The mission panel will be disappeared
            FirstPanel.SetActive(false);
            SecondPanel.SetActive(false);
            ThridPanel.SetActive(false);

        }
    }

    void fadeIn()
    {
        DeadBackground.CrossFadeAlpha(1, 2, false);
        DeadText.CrossFadeAlpha(2, 2, false);
        DeadHint.CrossFadeAlpha(2, 2, false);
    }

    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            health += 40;
            hpImg.fillAmount = health / 100;
            if (health >= 100)
            {
                health = 100;
            }
            print("Lives added");

            LivesAdd.Play();
            DeadMusic.Stop();
        }

        if(other.gameObject.tag == "Energy")
        {
            DeadMusic.Stop();

            Destroy(other.gameObject);
            CountNum++;
            print(CountNum);
            
            if (CountNum == 3)
            {
                PointerForBoss.SetActive(true);
                BossPanel.SetActive(true);
                Pointer.SetActive(false);
                BossDoor.SetActive(true);
            }
        }
    }

   
}
