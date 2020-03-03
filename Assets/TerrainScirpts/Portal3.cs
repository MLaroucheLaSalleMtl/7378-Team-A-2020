using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal3 : MonoBehaviour
{
    public Transform level3Gozone;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = level3Gozone.position;
           
        }

    }
}
