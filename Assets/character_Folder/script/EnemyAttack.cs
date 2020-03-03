using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10f;
    private Animator anim;
    public Transform detectDamage;
    public LayerMask playerLayer;
    bool finishAttack = false;
    private playerHealth playHP;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        playHP = player.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfAttacking();
        if (finishAttack)
        {
            playHP.takeDamage(damage);
            finishAttack = false;
        }
    }

   void checkIfAttacking()
    {
        if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("BasicAttack") || anim.GetCurrentAnimatorStateInfo(0).IsName("HornAttack"))
        {
           if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                finishAttack = true;
            }
            else
            {
                finishAttack = false;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectDamage.position, 0.8f);
    }

    
}
