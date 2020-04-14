using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillEffect : MonoBehaviour
{
    private float speed = 5f;
    private Transform player;
    private Vector3 playerPos;
    public GameObject fireball;
    private GameObject boss;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 firePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        instantiateBall();
        if (isAttacking)
        {
            GameObject ball = Instantiate(fireball, firePos, Quaternion.identity);
            isAttacking = false;
        }
    }

    void instantiateBall()
    {
        if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FireballShoot") || boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FlyFireballShoot"))
        {
            Debug.Log("before" + boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
            if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f && boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.7f)
            {
                Debug.Log("after anim" + boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
                isAttacking = true;
            }
        }
    }
}
