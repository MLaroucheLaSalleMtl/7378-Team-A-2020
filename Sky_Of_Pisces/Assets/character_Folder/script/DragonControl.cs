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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
        }
    }

    public void searchPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(tpuc.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(tpuc.transform.position, transform.position) < viewDistance)
            {
                onAware();
            }
        }
    }

    public void onAware()
    {
        isAware = true;
    }
}
