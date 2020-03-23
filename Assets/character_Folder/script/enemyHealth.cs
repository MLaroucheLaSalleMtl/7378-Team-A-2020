using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float health = 100;
    private Animator anim;
    public bool isDead;
    //public GameObject hpp;
    private DragonControl dc;
    public GameObject health_img;
    public bool isDestroy =false;

    //UI       
    public GameObject FinishQuestPanel;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject BackPortal;
    public GameObject BackPortalForAnt;
    public GameObject BackPortalForEagle;

    public GameObject PointerForCollection;
    private void Start()
    {
        anim = GetComponent<Animator>();
        isDead = false;
        dc = GetComponent<DragonControl>();
        if(tag == "boss")
        {
            health_img = GameObject.Find("boss_hp");
        }
        else
        {
            health_img = GameObject.Find("dragon_hp");
        }
        health_img.GetComponent<Image>().fillAmount = 1;
    }

    private void Update()
    {        
        //if (isDead && isDestroy)
        //{           
        //    Instantiate(hpp, transform.position, Quaternion.identity);
        //}
        //else
        //{
        //    isDestroy = false;
        //}
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        health_img.GetComponent<Image>().fillAmount -= health / 100;
        
        //Debug.Log(health);
        if(health <= 0)
        {            
            health = 0;
            die();

            if (DialogueManager.id == 1)
            {
                //Eagle
                skill1.SetActive(true);
                FinishQuestPanel.SetActive(true);       
                BackPortalForAnt.SetActive(false);
                BackPortal.SetActive(false);
                BackPortalForEagle.SetActive(true);
               
            }
            if (DialogueManager.id == 2)
            {
                //Bandger
                skill2.SetActive(true);
                FinishQuestPanel.SetActive(true);     
                BackPortal.SetActive(true);
                BackPortalForAnt.SetActive(false);
                BackPortalForEagle.SetActive(false);
               
            }
            if (DialogueManager.id == 3)
            {
                //Ant
                FinishQuestPanel.SetActive(true);                
                BackPortalForAnt.SetActive(true);
                BackPortalForEagle.SetActive(false);
                BackPortal.SetActive(false);

                PointerForCollection.SetActive(true);

            }
           
        }
    }

    void die()
    {
        dc.dragonCurrentState = dragonState.Death;
        isDead = true;       
    }

    

}
