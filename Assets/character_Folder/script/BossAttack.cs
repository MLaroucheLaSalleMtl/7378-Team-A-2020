using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float damage = 10f;
    private Animator anim;
    public LayerMask playerLayer;
    private playerHealth playerHP;
    Transform player;
    bool endAttack = true;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        playerHP = player.GetComponent<playerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if (endAttack)
        {
            DealDamage(checkIfAttacking());
        }
        else
        {
            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                endAttack = true;
            }
        }
    }

    bool checkIfAttacking()
    {
        bool isAttacking = false;
        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("BasicAttack") || anim.GetCurrentAnimatorStateInfo(0).IsName("TailAttack"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                isAttacking = true;
                endAttack = false;
            }
        }
        return isAttacking;
    }

    void DealDamage(bool isAttacking)
    {
        if (isAttacking)
        {
            //Debug.Log(Vector3.Distance(transform.position, player.position));
            if (Vector3.Distance(transform.position, player.position) <= 5f)
            {
                playerHP.takeDamage(damage);
            }
        }
    }
}
