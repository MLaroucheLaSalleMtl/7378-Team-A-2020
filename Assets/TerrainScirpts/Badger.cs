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
    
    // Start is called before the first frame update
    void Start()
    {
        
        BadgerName.canvasRenderer.SetAlpha(0.0f);
        BadgerNameBorder.canvasRenderer.SetAlpha(0.0f);
    }

    public void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) <= 50f)
        {          
            fadeIn();
            arrow.SetActive(false);           
        }
        else 
        {
            fadeOut();
            FirstQuest.SetActive(false);
            //arrow.SetActive(false);
           
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

}
