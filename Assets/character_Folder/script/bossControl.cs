using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum bossState
{
    Idle,
    Walk,
    Run,
    Pause,
    Attack,
    Death,
    Sleep,
}
public class bossControl : MonoBehaviour
{
    private float attackDis = 1.5f;
    private float alert_Attack_Distance = 8f;
    private float followDistance = 15f;
    private float enemyToPlayerDistance;

    private bossState boss_currentState = bossState.Sleep;
    private bossState boss_lastState = bossState.Sleep;

    private Transform player;
    private NavMeshAgent agent;
    private float currentAttackTime;
    private float waitAttackTime = 1f;
    private enemyHealth bossHp;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        bossHp = GetComponent<enemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (boss_currentState != bossState.Death)
        {
            setBossState();
        }
    }

    void setBossState()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (bossHp.health < 100)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Run", true);
            agent.SetDestination(player.position);
            agent.isStopped = false;
            if (distance <= 5f)
            {
                agent.isStopped = true;
                anim.SetBool("Run", false);
                Vector3 targetPosition = new Vector3(player.position.x, player.position.y, player.position.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), 5f * Time.deltaTime);
                if (currentAttackTime >= waitAttackTime)
                {
                    int attackRange = Random.Range(1, 4);
                    Debug.Log(attackRange);
                    anim.SetInteger("Attack", attackRange);
                    currentAttackTime = 0f;
                }
                else
                {
                    anim.SetInteger("Attack", 0);
                    currentAttackTime += Time.deltaTime;
                }
            }
            //else if(attackRange == 4)
            //{
            //    anim.SetBool("TakeOff", true);
            //    if(anim.GetCurrentAnimatorStateInfo(0).IsName("TakeOff") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f)
            //    {
            //        anim.SetInteger("Attack", 4);
            //        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyFireballShoot") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            //        {
            //            anim.SetBool("Land", true);
            //            anim.SetBool("TakeOff", false);
            //            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Land") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            //            {
            //                anim.SetBool("Land", false);
            //                anim.SetInteger("Attack", 0);
            //                anim.SetBool("Idle", true);
            //            }
            //        }
            //    }
            //}
        }
        else
        {
            agent.isStopped = true;
        }

        

    }
}
