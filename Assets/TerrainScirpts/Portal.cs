using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform level1Gozone;
    

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = level1Gozone.position;
           
        }
      
    }



}
