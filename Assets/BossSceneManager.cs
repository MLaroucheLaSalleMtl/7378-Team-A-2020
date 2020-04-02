using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSceneManager : MonoBehaviour
{    

    public CameraShake camerShake;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Player")
        {
            StartCoroutine(camerShake.Shake(.80f, .8f));
        }
    }
    //void Start()
    //{
    //    StartCoroutine(camerShake.Shake(.80f, .8f));
        
    //}
    void Update()
    {
        StartCoroutine(camerShake.Shake(.80f, .8f));

    }


}
