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

    private void Update()
    {
        GenerateHealth();
    }

    void GenerateHealth()
    {
        //if () this will depend on boss hp
        //{
        //    Instantiate(HPGenerator, transform.position, transform.rotation);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Yes");
            if (GameObject.Find("character").GetComponent<playerHealth>().health <= 100)
            {
                GameObject.Find("character").GetComponent<playerHealth>().health += 30;
                hpImg.fillAmount = GameObject.Find("character").GetComponent<playerHealth>().health / 100;
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
