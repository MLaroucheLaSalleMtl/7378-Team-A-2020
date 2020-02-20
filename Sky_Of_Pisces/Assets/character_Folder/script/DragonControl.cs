using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderPoint = RandomWanderPos();
        anim = GetComponent<Animator>();
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
