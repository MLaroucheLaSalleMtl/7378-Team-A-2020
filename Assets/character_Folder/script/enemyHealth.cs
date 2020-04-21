using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public int health;
    private Animator anim;
    public bool isDead;
    public GameObject hpp;
    private DragonControl dc;
    private BossState state;

    //UI       
    public GameObject FinishQuestPanel;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject BackPortal;
    public GameObject BackPortalForAnt;
    public GameObject BackPortalForEagle;

    public GameObject PointerForCollection;
    public GameObject DefeatPanel;
   
    
    public GameObject TriggerQuest;
    public HealthBar healthbar;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        isDead = false;
        dc = GetComponent<DragonControl>();
        healthbar.setMaxHp(health);

        state = GetComponent<BossState>();
        //TriggerQuest.SetActive(false);
    }

    
    public void takeDamage(int damage)
    {
        health -= damage;
        healthbar.setHealth(health);
        //Debug.Log(health_img.fillAmount);
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

                Instantiate(hpp, transform.position, transform.rotation);
               
            }
            if (DialogueManager.id == 0)
            {
                //Bandger
                skill2.SetActive(true);
                FinishQuestPanel.SetActive(true);     
                BackPortal.SetActive(true);
                BackPortalForAnt.SetActive(false);
                BackPortalForEagle.SetActive(false);

                Instantiate(hpp, transform.position, transform.rotation);
                
            }
            if (DialogueManager.id == 6)
            {
                //Ant
                FinishQuestPanel.SetActive(true);                
                BackPortalForAnt.SetActive(true);
                BackPortalForEagle.SetActive(false);
                BackPortal.SetActive(false);

                PointerForCollection.SetActive(true);
                

                Instantiate(hpp, transform.position, transform.rotation);
                
                TriggerQuest.SetActive(true);
            }
           
        }
    }

    void die()
    {
        //if (tag == "Boss")
        //{
        //    state.Boss_State = Boss_State.death;
        //}
        //else
        //{
        if(tag=="Enemy")
            dc.dragonCurrentState = dragonState.Death;
        isDead = true;

        if (tag == "Boss")
        {
            isDead = true;
        }
          
    }
}
