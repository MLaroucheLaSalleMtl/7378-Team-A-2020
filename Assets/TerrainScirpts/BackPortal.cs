using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPortal : MonoBehaviour
{
    public Transform  backTown;
    public GameObject QuestPanel;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = backTown.position;
            QuestPanel.SetActive(false);
            //GameObject.Find("ArrowManager").GetComponent<DirectionalArrow>().arrow.SetActive(false);
        }

    }
}
