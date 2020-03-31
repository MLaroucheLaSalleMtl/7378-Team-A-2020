using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    public Transform Eagle;
    public Transform Ant;
    public Transform Badger;
   
    //Quest mark
    public GameObject arrow;
    
    public void Update()
    {
        if (DialogueManager.id == 1)
        {
            Vector3 targetPos = Eagle.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            
            arrow.SetActive(true);
        }
        if (DialogueManager.id == 2)
        {
            arrow.SetActive(true);
            Vector3 targetPos = Badger.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }
        if (DialogueManager.id == 3)
        {
            arrow.SetActive(true);
            Vector3 targetPos = Ant.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }
        
        

    }
    
        
    
}
