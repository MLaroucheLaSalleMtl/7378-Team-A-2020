using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillEffect : MonoBehaviour
{
    private float speed = 5f;
    private Transform player;
    private Vector3 playerPos;
    public GameObject fireball;
    private Transform firelaser;
    private GameObject boss;
    private bool isFireBall;
    private bool isFireBaser;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.Find("Boss");
        firelaser = transform.Find("firball laser");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 firePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        instantiateBall();
        if (isFireBall)
        {
            GameObject ball = Instantiate(fireball, firePos, Quaternion.identity);
            isFireBall = false;
        }else if (isFireBaser)
            {
            firelaser.gameObject.SetActive(true);
            //if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            //{
            //    firelaser.gameObject.SetActive(false);
            //}
        }
    }

    void instantiateBall()
    {
        if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FireballShoot"))
        {
            //Debug.Log("before" + boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
            if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.55f && boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.57f)
            {
                //Debug.Log("after anim" + boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
                isFireBall = true;
            }
        }
        else if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FlyFireballShoot"))
        {
            isFireBaser = true;
            if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                isFireBaser = false;
            }
        }
    }
}
