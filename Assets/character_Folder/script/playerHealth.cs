using System.Collections;
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
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
        DeadMusic = GetComponent<AudioSource>();
        
        DeadBackground.canvasRenderer.SetAlpha(0.0f);
        DeadHint.canvasRenderer.SetAlpha(0.0f);
        DeadText.canvasRenderer.SetAlpha(0.0f);

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
           
            //----- 

        }
    }

    void fadeIn()
    {
        DeadBackground.CrossFadeAlpha(1, 2, false);
        DeadText.CrossFadeAlpha(2, 2, false);
        DeadHint.CrossFadeAlpha(2, 2, false);
    }
}
