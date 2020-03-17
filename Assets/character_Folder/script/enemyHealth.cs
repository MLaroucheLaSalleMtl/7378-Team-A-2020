using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float health = 100;
    private Animator anim;
    public bool isDead;
    public GameObject hpp;
    private DragonControl dc;
    private Image health_img;

    //UI       
    public GameObject FirstQuest;
    public GameObject SkillPanel;
    public GameObject BackPortal;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isDead = false;
        dc = GetComponent<DragonControl>();
        if(tag == "boss")
        {
            health_img = GameObject.Find("boss_hp").GetComponent<Image>();
        }
        else
        {
            health_img = GameObject.Find("dragon_hp").GetComponent<Image>();
        }
        health_img.fillAmount = 1;

       
    }

    private void Update()
    {        
        if (isDead)
        {           
            Instantiate(hpp, transform.position, transform.rotation);           
        }        
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        health_img.fillAmount = health / 100f;
        if(health <= 0)
        {            
            health = 0;
            die();

            print("Test");
            FirstQuest.SetActive(true);
            SkillPanel.SetActive(true);
            BackPortal.SetActive(true);
        }
    }

    void die()
    {
        dc.dragonCurrentState = dragonState.Death;
        isDead = true;       
    }

    

}
