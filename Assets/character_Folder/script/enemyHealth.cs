using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float health = 100;
    public Image healthImg;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void takeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            health = 0;
            die();
        }
    }

    void die()
    {
        anim.SetBool("Die", true);
        Destroy(this, 2f);
    }
}
