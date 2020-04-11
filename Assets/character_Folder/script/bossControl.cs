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
            int attackRange = Random.Range(1, 2);
            if (attackRange == 1 || attackRange == 2)
            {
                if (distance > 5f)
                {
                    anim.SetBool("Run", true);
                    agent.SetDestination(player.position);
                    agent.isStopped = false;
                }
                else
                {
                    agent.isStopped = true;
                    anim.SetBool("Run", false);
                    Vector3 targetPosition = new Vector3(player.position.x, player.position.y, player.position.z);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), 5f * Time.deltaTime);
                    if (currentAttackTime >= waitAttackTime)
                    {
                        anim.SetInteger("Attack", 1);
                        currentAttackTime = 0f;
                    }
                    else
                    {
                        anim.SetInteger("Attack", 0);
                        currentAttackTime += Time.deltaTime;
                    }
                }
            }
            else if (attackRange == 3)
            {
                agent.isStopped = true;
                anim.SetInteger("Attack", 3);
            }
        }
        else
        {
            agent.isStopped = true;
        }

        

    }
}
