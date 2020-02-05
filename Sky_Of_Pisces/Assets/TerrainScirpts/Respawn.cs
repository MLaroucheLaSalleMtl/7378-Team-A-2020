using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public Transform RespawnPlayer;
    public AudioSource LostVoice;
    //public Image ResSpawnFade;

    void Start()
    {
        LostVoice = GetComponent<AudioSource>();
        //ResSpawnFade.canvasRenderer.SetAlpha(0.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //fadeIn();
            //wait();
            LostVoice.Play();
            wait();
            other.gameObject.transform.position = RespawnPlayer.position;
            //fadeOut();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //fadeIn();
            //wait();
            LostVoice.Play();
            wait();
            other.gameObject.transform.position = RespawnPlayer.position;
            //fadeOut();
        }

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
    }

    //void fadeOut()
    //{
    //    ResSpawnFade.CrossFadeAlpha(0, 0.5f, false);
        
    //}

    //void fadeIn()
    //{
    //    ResSpawnFade.CrossFadeAlpha(1, 0.5f, false);
        
    //}
}
