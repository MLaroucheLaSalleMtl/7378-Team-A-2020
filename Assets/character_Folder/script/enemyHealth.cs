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
    public GameObject FinishQuestPanel;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject BackPortal;
    public GameObject BackPortalForAnt;
    public GameObject BackPortalForEagle;

    public GameObject PointerForCollection;
    public GameObject PointerForBoss;

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
            //health_img = GameObject.Find("dragon_hp").GetComponent<Image>();
            health_img = transform.Find("enemyHealth/dragon_hp").GetComponent<Image>();
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
        Debug.Log(health_img.fillAmount);
        if (health <= 0)
        {            
            health = 0;
            die();

           
            if (DialogueManager.id == 5)
            {
                //Eagle
                skill1.SetActive(true);
                FinishQuestPanel.SetActive(true);       
                BackPortalForAnt.SetActive(false);
                BackPortal.SetActive(false);
                BackPortalForEagle.SetActive(true);

               
            }
            if (DialogueManager.id == 0)
            {
                //Bandger
                skill2.SetActive(true);
                FinishQuestPanel.SetActive(true);     
                BackPortal.SetActive(true);
                BackPortalForAnt.SetActive(false);
                BackPortalForEagle.SetActive(false);

                
            }
            if (DialogueManager.id == 6)
            {
                //Ant
                FinishQuestPanel.SetActive(true);                
                BackPortalForAnt.SetActive(true);
                BackPortalForEagle.SetActive(false);
                BackPortal.SetActive(false);

                PointerForCollection.SetActive(true);
                PointerForBoss.SetActive(true);
            }
           
        }
    }

    void die()
    {
        dc.dragonCurrentState = dragonState.Death;
        isDead = true;       
    }

    

}
