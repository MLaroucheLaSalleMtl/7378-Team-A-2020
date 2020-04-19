using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Badger : MonoBehaviour
{
       
    public Text BadgerName;
    public Image BadgerNameBorder;
    public GameObject arrow;
    public Transform player;

    public GameObject FirstQuest;
    public AudioSource AttackMusic;

    // Start is called before the first frame update
    void Start()
    {
        
        BadgerName.canvasRenderer.SetAlpha(0.0f);
        BadgerNameBorder.canvasRenderer.SetAlpha(0.0f);
        AttackMusic = GetComponent<AudioSource>();
    }

    public void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) <= 50f)
        {
            DialogueManager.id = 0;
            fadeIn();
            arrow.SetActive(false);
            
        }
        if(Vector3.Distance(transform.position, player.transform.position) > 50f)
        {
            fadeOut();
            FirstQuest.SetActive(false);
            
        }
    }
    
    void fadeOut()
    {
        BadgerName.CrossFadeAlpha(0, 2, false);
        BadgerNameBorder.CrossFadeAlpha(0, 2, false);        
    }

    void fadeIn()
    {
        BadgerName.CrossFadeAlpha(1, 2, false);
        BadgerNameBorder.CrossFadeAlpha(1, 2, false);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AttackMusic.Play();
            GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Stop();
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        AttackMusic.Stop();
        //GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Play();

    }
}
