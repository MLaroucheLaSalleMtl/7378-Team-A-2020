using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

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
    private bool isAware = false;
    public float fov = 120f;
    public float viewDistance = 10;
    private NavMeshAgent agent;

    public float wanderRadius = 7f;
    private Vector3 wanderPoint;

    public Transform[] waypos;
    private int wayposIndex = 0;

    private Animator anim;

    private float attackDistance = 1.5f;
    private float alertAttackDis = 8f;
    private float followDis = 15f;
    private float enemyToPlayerDis;

    private dragonState dragonCurrentState = dragonState.Idle;
    private dragonState dragonLastState = dragonState.Idle;

    private Vector3 initialPos;
    private CharacterController charControl;
    private Vector3 WhereToGo = Vector3.zero;

    private float currentAttackTime;
    private float waitAttackTime = 1f;
    private bool finished_Animation = true;
    private bool finished_Movement = true;

    private Vector3 whereTo_Navigate;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderPoint = RandomWanderPos();
        anim = GetComponent<Animator>();
        charControl = GetComponent<CharacterController>();

        initialPos = transform.position;
        whereTo_Navigate = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAware)
        {
            agent.SetDestination(tpuc.transform.position);
        }
        else
        {
            searchPlayer();
            wander();
        }

        if(dragonCurrentState != dragonState.Death)
        {
            //dragonCurrentStare = SetDragonState
            if (finished_Movement)
            {
                //GetStateControl
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
            charControl.enabled = false;
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

        if (initialDistance > followDis)// if the dragon exceed the follow distance, it returns to the initial position, 怪物范围8以外会返回上一个state
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

    public void searchPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(tpuc.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(tpuc.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if(Physics.Linecast(transform.position,tpuc.transform.position,out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        onAware();
                        if (agent.remainingDistance < 8f)
                        {
                            anim.SetBool("Attack", true);
                        }
                        else
                        {
                            anim.SetBool("CornAttack", true);
                        }
                    }
                }
            }
        }
    }

    public void onAware()
    {
        isAware = true;
        anim.SetBool("Run", true);
    }

    public void wander()
    {
        //if (Vector3.Distance(transform.position, wanderPoint) < 2f)
        //{
        //    wanderPoint = RandomWanderPos(); //have reached it, make a new wanderpoint
        //}
        //else
        //{
        //    agent.SetDestination(wanderPoint); //have not reach it, move to the wanderpoint
        //}
        
        if (Vector3.Distance(waypos[wayposIndex].position, transform.position) < 2f) //return the distance between the wandering position and enemy position
        {
            if (wayposIndex == waypos.Length - 1)
            {
                wayposIndex = 0;
            }
            else
            {
                
                wayposIndex++;
            }
        }
        else
        {
            agent.SetDestination(waypos[wayposIndex].position);
        }

    }

    public Vector3 RandomWanderPos()
    {
        Vector3 randomPos = (Random.insideUnitSphere * wanderRadius) + transform.position; //this sphere is made in the 0 orgin of the world, to make it in different we need to add the vector(transform)
        NavMeshHit navhit;//to hold the property of resulting location
        NavMesh.SamplePosition(randomPos, out navhit, wanderRadius, -1);//finds the closest point
        return new Vector3(navhit.position.x, transform.position.y,navhit.position.z);  //returns the nearest x and z, y does not change
    }
}
