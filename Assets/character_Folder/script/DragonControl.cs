using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public enum dragonState
{
    Idle,
    Walk,
    Run,
    Pause,
    BackToWander,
    Attack,
    Death
}
public class DragonControl : MonoBehaviour
{
    public ThirdPersonUserControl tpuc;
    public float fov = 120f;
    public float viewDistance = 10;
    private NavMeshAgent agent;

    public float wanderRadius = 7f;
    private Vector3 wanderPoint;

    private int wayposIndex = 0;

    private Animator anim;

    private float attackDistance = 5f;
    private float alertAttackDis = 8f;
    private float followDis = 15f;
    private float enemyToPlayerDis;

    [HideInInspector]
    public dragonState dragonCurrentState = dragonState.Idle;
    public dragonState dragonLastState = dragonState.Idle;

    private Vector3 initialPos;
    private Vector3 WhereToGo = Vector3.zero;

    private float currentAttackTime;
    private float waitAttackTime = 1f;
    private bool finished_Animation = true;
    private bool finished_Movement = true;

    private Vector3 whereTo_Navigate;

    private enemyHealth enemyHP;

    
    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        initialPos = transform.position;
        whereTo_Navigate = transform.position;

        wanderPoint = RandomWanderPoint();

        enemyHP = GetComponent<enemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyHP.health <= 0)
        {
            dragonCurrentState = dragonState.Death;
        }
        if(dragonCurrentState != dragonState.Death)
        {
            dragonCurrentState = SetDragonState(dragonCurrentState, dragonLastState, enemyToPlayerDis);
            if (finished_Movement)
            {
                dragonStateControl(dragonCurrentState);
            }
            else
            {
                if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) //animation is not in transition && it is idle state
                {
                    finished_Movement = true;
                }
                else if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsTag("BasicAttack") || anim.GetCurrentAnimatorStateInfo(0).IsTag("HornAttack"))
                {
                    anim.SetInteger("Attack", 1);
                }
            }
        }
        else
        {
            anim.SetBool("Die", true);
            agent.enabled = false;
            if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Die") &&anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)// 1 is the end of animation
            {
                Destroy(gameObject, 2f);
            }
        }
    }

    dragonState SetDragonState(dragonState currentState, dragonState lastState, float dragonToPlayerDis)
    {
        float initialDistance = Vector3.Distance(initialPos, transform.position); //this calculate the distance between the original position and current position
        dragonToPlayerDis = Vector3.Distance(transform.position, tpuc.transform.position);
        
        if (initialDistance > followDis || playerHealth.instance.health<=0)// if the dragon exceed the follow distance, it returns to the initial position, 怪物范围8以外会返回上一个state
        {
            lastState = currentState;  //lets say the dragon is chesing the player, if it exceed 8, the state of chasing became last state
            currentState = dragonState.BackToWander;
        }
        else if (dragonToPlayerDis < attackDistance)
        {
            lastState = currentState;
            currentState = dragonState.Attack;
        }
        else if (dragonToPlayerDis >= alertAttackDis && lastState == dragonState.Pause || lastState == dragonState.Attack) //player runs away, chase player
        {
            lastState = currentState;
            currentState = dragonState.Pause;  
        }
        else if (dragonToPlayerDis <= alertAttackDis && dragonToPlayerDis > attackDistance) //chase player
        {
            if (currentState != dragonState.BackToWander || lastState == dragonState.Attack)
            {
                lastState = currentState;
                currentState = dragonState.Pause;
            }
        } else if (dragonToPlayerDis > alertAttackDis && lastState != dragonState.BackToWander && lastState != dragonState.Pause)
        {
            lastState = currentState;
            currentState = dragonState.Walk;
        }


        return currentState;
    }

    void dragonStateControl(dragonState currentState)
    {
        if(currentState == dragonState.Run || currentState == dragonState.Pause)
        {
            if (currentState != dragonState.Attack)
            {
                Vector3 playerPosition = new Vector3(tpuc.transform.position.x, tpuc.transform.position.y, tpuc.transform.position.z);
                if (Vector3.Distance(transform.position, playerPosition) >= 2.1f)
                {
                        anim.SetBool("Walk", false);
                        anim.SetBool("Run", true);
                        agent.SetDestination(playerPosition);
                }
            }
        }
        else if(currentState == dragonState.Attack)
        {
            anim.SetBool("Run", false);
            WhereToGo.Set(0f, 0f, 0f);
            agent.SetDestination(transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tpuc.transform.position - transform.position), 5f * Time.deltaTime); // keep looking at the player
            //https://www.youtube.com/watch?v=xppompv1DBg&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=11

            if (currentAttackTime >= waitAttackTime)//wait one sec and attack
            {
                int attackRange = Random.Range(1, 3);
                anim.SetInteger("Attack", attackRange);
                finished_Animation = false;
                currentAttackTime = 0; //reset attack time
            }
            else
            {
                anim.SetInteger("Attack", 0);
                currentAttackTime += Time.deltaTime;
            }
        }
        else if(currentState == dragonState.BackToWander)
        {
            anim.SetBool("Run", true);
            Vector3 targetPosition = new Vector3(initialPos.x, transform.position.y, initialPos.z);
            agent.SetDestination(targetPosition);
            if (Vector3.Distance(targetPosition,initialPos) <= 0.5f)
            {
                dragonLastState = currentState;
                currentState = dragonState.Walk;
            }
        }
        else if(currentState == dragonState.Walk)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", true);
            //if (Vector3.Distance(transform.position,wanderPoint) < 5f)
            //{
            //    wanderPoint = RandomWanderPoint();
            //}
            //else
            //{
            //    agent.SetDestination(wanderPoint);
            //}
            if (Vector3.Distance(transform.position, whereTo_Navigate) <= 5f)
            {
                whereTo_Navigate.x = Random.Range(initialPos.x - 10f, initialPos.x + 10f);
                whereTo_Navigate.z = Random.Range(initialPos.z - 10f, initialPos.z + 10f);
                //get idea from https://www.youtube.com/watch?v=Puqupldb4yc
            }
            else
            {
                agent.SetDestination(whereTo_Navigate);
            }
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
            WhereToGo.Set(0f, 0f, 0f);
            agent.isStopped = true;
        }
    }
    public Vector3 RandomWanderPoint()
    {
        Vector3 randompoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randompoint, out hit, wanderRadius, -1);
        return new Vector3(hit.position.x, transform.position.y, hit.position.z);
        //dragon wander
        //https://www.youtube.com/watch?v=U1nPbJZ1hlc&t=230s
    }



}
