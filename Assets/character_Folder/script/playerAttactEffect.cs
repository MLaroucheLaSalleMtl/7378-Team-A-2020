using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttactEffect : MonoBehaviour
{
    public GameObject lightingEffect;
    public GameObject magicCircleEffect;
    public GameObject magicCircleEffectPos;
    public GameObject swordTrail;

    private float mainTime = 15f;
    private float currentTime;
    bool startCount = false;
    private playerAttack damage;

    //bool increaseDamage = false;
    private void Start()
    {
        currentTime = mainTime;
        damage = GetComponent<playerAttack>();
    }
    private void Update()
    {
        if (startCount)
        {
            if (currentTime >= 0f)
            {
                currentTime -= Time.deltaTime;
                damage.damage = 25;
                swordTrail.SetActive(true);
            }
            else if (currentTime <= 0f)
            {
                currentTime = mainTime;
                startCount = false;
                damage.damage = 20;
                swordTrail.SetActive(false);
            }
        }
    }

    public void magicCircle()
    {
        Instantiate(magicCircleEffect, magicCircleEffectPos.transform.position, Quaternion.identity);
        startCount = true;
    }

    public void lighting()
    {
        for(int i = 0; i < 4; i++)
        {
            Vector3 pos = Vector3.zero;
            if(i == 0)
            {
                pos = new Vector3(transform.position.x - 4f, transform.position.y + 3f, transform.position.z);
            }
            if (i == 1)
            {
                pos = new Vector3(transform.position.x + 4f, transform.position.y + 3f, transform.position.z);
            }
            if (i == 2)
            {
                pos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z - 4f);
            }
            if (i == 3)
            {
                pos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z + 4f);
            }

            Instantiate(lightingEffect, pos, Quaternion.identity);
        }
    }

    //void onMagicCircle()
    //{
    //    if (increaseDamage)
    //    {
    //        playerAttack.instance.damage = 25;
    //    }
    //}
    
}
