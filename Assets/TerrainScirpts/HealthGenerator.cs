using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGenerator : MonoBehaviour
{

    public Image hpImg;
    public AudioSource LivesAdd;
    public GameObject HPGenerator;

    private void Start()
    {
        LivesAdd = GetComponent<AudioSource>();
    }  
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            if (GameObject.Find("character").GetComponent<playerHealth>().health < 100)
            {
                GameObject.Find("character").GetComponent<playerHealth>().health += 40;
                GameObject.Find("character").GetComponent<playerHealth>().hpImg.fillAmount = GameObject.Find("character").GetComponent<playerHealth>().health / 100;
                LivesAdd.Play();
                StartCoroutine(SetActiveFalse());
            }

            

        }
    }

    IEnumerator SetActiveFalse()
    {
        yield return new WaitForSeconds(1);
        HPGenerator.SetActive(false);
    }
}
