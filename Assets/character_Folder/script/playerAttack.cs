using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class playerAttack : MonoBehaviour
{
    public bool CanAttack;
    public Image fillSkill1;
    public Image fillSkill2;

    Animator anim;
    public int numOfclick = 0;
    float lastClickTime = 0;
    float maxDelay = 1f;
    public float damage = 20;

    bool Fire = false;

    //public Transform start;
    //public Transform end;
    public Transform attackArea;
    public float attackRange = 0.8f;

    public LayerMask enemylayer; //in order to seperate boss and normal enemy

    public bool canPlaySkill1 = false;
    public bool canPlaySkill2 = false;

    private playerAttactEffect effect;

    public static playerAttack instance;
    public GameObject skill1;
    public GameObject skill2;

    public GameObject mission1;

    public bool canPlayLighting;
    public bool canPlayPowerup;

    public Image EnegyImg;
    private float enegy;
    private float enegyConsume;
    private playerHealth ph;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        effect = GetComponent<playerAttactEffect>();
        ph = GetComponent<playerHealth>();
        instance = this;
        CanAttack = true;
        canPlayLighting = false;
        canPlayPowerup = false;
        enegy = 100;
        EnegyImg.fillAmount = enegy / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastClickTime > maxDelay)
        {
            numOfclick = 0;
            anim.SetBool("A1", false);
            anim.SetBool("A2", false);
            anim.SetBool("A3", false);
        }

        if (canPlaySkill1)
        {
            fadeInOut(fillSkill1, 0.7f);
            if (canPlayLighting)
            {
                enegy -= 10;
                EnegyImg.fillAmount = enegy / 100;
                canPlayLighting = false;
            }
        }
        else if (canPlaySkill2)
        {
            fadeInOut(fillSkill2, 1f);
            if (canPlayPowerup)
            {
                enegy -= 5;
                EnegyImg.fillAmount = enegy / 100;
                canPlayPowerup = false;
            }
        }
        if (ph.canAddEnegy && enegy < 100)
        {
            enegy += 10;
            EnegyImg.fillAmount = enegy / 100f;
            ph.canAddEnegy = false;
            if (EnegyImg.fillAmount >= 1)
            {
                EnegyImg.fillAmount = 1;
            }
        }
        
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if(CanAttack)
        {
            if (Fire = context.performed)
            {
                lastClickTime = Time.time;
                numOfclick++;
            }

            if (numOfclick >= 1)
            {
                anim.SetBool("A1", true);
            }
            if (numOfclick >= 2)
            {
                anim.SetBool("A2", true);
            }
            if (numOfclick >= 3)
            {
                anim.SetBool("A3", true);
            }
        }


        Collider[] touchEnemy = Physics.OverlapSphere(attackArea.position, attackRange, enemylayer);//collects the gameobject with layer "enemy"

        foreach (Collider enemy in touchEnemy)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("slash1") || anim.GetCurrentAnimatorStateInfo(0).IsName("slash3") || anim.GetCurrentAnimatorStateInfo(0).IsName("slash4"))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.07f)
                {
                    enemy.GetComponent<enemyHealth>().takeDamage(damage);
                }
            }
        }
    }


    public void Skill1(InputAction.CallbackContext context)
    {
        if (skill1.activeInHierarchy)
        {
            if (mission1.activeInHierarchy)
            {
                if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded") && EnegyImg.fillAmount >= 10 / 100)
                {
                        anim.SetInteger("Skill", 1);
                        canPlaySkill1 = true;
                        effect.lighting();
                        canPlayLighting = true;
                }
                else
                {
                    anim.SetInteger("Skill", 0);
                }
            }
        }
    }

    public void Skill2(InputAction.CallbackContext context)
    {
        if (skill2.activeInHierarchy)
        {
            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded") && EnegyImg.fillAmount >= 10 / 100)
            {
                    anim.SetInteger("Skill", 2);
                    canPlaySkill2 = true;
                    effect.magicCircle();
                    canPlayPowerup = true;
            }
            else
            {
                anim.SetInteger("Skill", 0);
            }
        }
    }

    void fadeInOut(Image fadeImg, float fadeTime)
    {
        if (fadeImg == null)
            return;

        if (!fadeImg.gameObject.activeInHierarchy)
        {
            fadeImg.gameObject.SetActive(true);
            fadeImg.fillAmount = 1f;
        }

        fadeImg.fillAmount -= fadeTime * Time.deltaTime;

        if (fadeImg.fillAmount <= 0f)
        {
            fadeImg.gameObject.SetActive(false);
            if (canPlaySkill1)
            {
                canPlaySkill1 = false;
            } else if (canPlaySkill2)
            {
                canPlaySkill2 = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackArea.position, attackRange);
    }

}
