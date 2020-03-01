using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Badger : MonoBehaviour
{
       
    public Text BadgerName;
    public Image BadgerNameBorder;
   
    // Start is called before the first frame update
    void Start()
    {
        
        BadgerName.canvasRenderer.SetAlpha(0.0f);
        BadgerNameBorder.canvasRenderer.SetAlpha(0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GameObject.Find("ArrowManager").GetComponent<DirectionalArrow>().arrow.SetActive(false);
            fadeIn();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            
            fadeOut();

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
