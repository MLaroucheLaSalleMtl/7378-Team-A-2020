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

    private void Start()
    {
        anim = GetComponent<Animator>();
        isDead = false;
        dc = GetComponent<DragonControl>();
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
        Debug.Log(health);
        if(health <= 0)
        {
            health = 0;
            die();
        }
    }

    void die()
    {
        dc.dragonCurrentState = dragonState.Death;
        isDead = true;
    }
}
