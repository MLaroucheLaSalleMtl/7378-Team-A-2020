using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossControl : MonoBehaviour
{
    private float enemyToPlayerDistance;

    private Transform player;
    private NavMeshAgent agent;
    private float currentAttackTime;
    private float waitAttackTime = 1f;
    private float waitSkillTime = 5f;
    private enemyHealth bossHp;
    bool finishAttack = true;
    private BossState state;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        bossHp = GetComponent<enemyHealth>();
        state = GetComponent<BossState>();
    }

    // Update is called once per frame
    void Update()
    {

        if (finishAttack)
        {
            setBossState();
        }
        else
        {
            anim.SetInteger("Attack", 0);
            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                finishAttack = true;
            }
        }
    }

    void setBossState()
    {
        if (state.Boss_State == Boss_State.death)
        {
            agent.isStopped = true;
            anim.SetBool("Die", true);
            Destroy(gameObject, 2f);
        }
        else
        {
            if (state.Boss_State == Boss_State.run)
            {
                agent.isStopped = false;
                anim.SetBool("Run", true);
                agent.SetDestination(player.position);
                int skillRange = 0;
                if (currentAttackTime >= waitSkillTime)
                {
                    anim.SetBool("Run", false);
                    skillRange = Random.Range(3, 5);
                    anim.SetInteger("Attack", skillRange);
                    finishAttack = false;
                    currentAttackTime = 0f;
                }
                else if(skillRange!=3&& skillRange!=4)
                {
                   // Debug.LogError("重置了" + Time.time);
                    //anim.SetInteger("Attack", 0);
                    currentAttackTime += Time.deltaTime;
                }
            }
            else if (state.Boss_State == Boss_State.attack)
            {
                anim.SetBool("Run", false);
                Vector3 targetPosition = new Vector3(player.position.x, player.position.y, player.position.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), 5f * Time.deltaTime);

                if (currentAttackTime >= waitAttackTime)
                {
                    int range = Random.Range(1, 3);
                    anim.SetInteger("Attack", range);
                    finishAttack = false;
                    currentAttackTime = 0f;
                }
                else
                {
                    //anim.SetInteger("Attack", 0);
                    currentAttackTime += Time.deltaTime;
                }
            }
        }

        //void setBossState()
        //{
        //    float distance = Vector3.Distance(transform.position, player.position);
        //    if (bossHp.health < 100)
        //    {
        //        anim.SetBool("Run", true);
        //        agent.SetDestination(player.position);
        //        agent.isStopped = false;
        //        if (distance <= 5f)
        //        {
        //            agent.isStopped = true;
        //            anim.SetBool("Run", false);
        //            if (currentAttackTime >= waitAttackTime)
        //            {
        //                int attackRange = Random.Range(1, 2);
        //                if (attackRange == 1 || attackRange == 2)
        //                {
        //                    Debug.Log(agent.isStopped);
        //                    Vector3 targetPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        //                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), 5f * Time.deltaTime);
        //                    anim.SetInteger("Attack", attackRange);
        //                }
        //                currentAttackTime = 0f;
        //            }
        //            else
        //            {
        //                anim.SetInteger("Attack", 0);
        //                currentAttackTime += Time.deltaTime;
        //            }
        //        }
        //        else if (distance > 5f && distance < 12f)
        //        {
        //            int skillAtkRange = Random.Range(1, 2);
        //            if (skillAtkRange == 3 || skillAtkRange == 4)
        //            {
        //                agent.isStopped = true;
        //                anim.SetBool("Run", false);
        //                anim.SetInteger("Attack", skillAtkRange);
        //            }
        //        }





        //        //else if(attackRange == 4)
        //        //{
        //        //    anim.SetBool("TakeOff", true);
        //        //    if(anim.GetCurrentAnimatorStateInfo(0).IsName("TakeOff") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f)
        //        //    {
        //        //        anim.SetInteger("Attack", 4);
        //        //        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyFireballShoot") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        //        //        {
        //        //            anim.SetBool("Land", true);
        //        //            anim.SetBool("TakeOff", false);
        //        //            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Land") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        //        //            {
        //        //                anim.SetBool("Land", false);
        //        //                anim.SetInteger("Attack", 0);
        //        //                anim.SetBool("Idle", true);
        //        //            }
        //        //        }
        //        //    }
        //        //}
        //    }
        //    else
        //    {
        //        anim.SetBool("Run", false);
        //        agent.isStopped = false;
        //    }



        //}
    }
}
