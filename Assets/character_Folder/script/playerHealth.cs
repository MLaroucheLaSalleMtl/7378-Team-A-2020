using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health = 100f;
    private Animator anim;
    public Image hpImg;
    public static playerHealth instance;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        hpImg.fillAmount = health / 100;
        Debug.Log(health);
        if(health <= 0)
        {
            health = 0;
            anim.SetBool("Die", true);
        }
    }
}
