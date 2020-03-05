using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResPawnDead : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform resPoint;



    // Update is called once per frame
    void Update()
    {
        player.transform.position = resPoint.transform.position;
    }
}
