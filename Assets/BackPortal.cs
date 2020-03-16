using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPortal : MonoBehaviour
{
    public Transform  backTown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = backTown.position;

        }

    }
}
