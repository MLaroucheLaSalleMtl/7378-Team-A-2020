using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAdding : MonoBehaviour
{
    [SerializeField] public GameObject Healthadding;
    [SerializeField] public AudioSource HeadAddingSound;
    [SerializeField] public Image Hpimage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Lives added");
            StartCoroutine(DestoryHealthAdding());
            HeadAddingSound.Play();

            GameObject.Find("character").GetComponent<playerHealth>().health +=10;
            Hpimage.fillAmount = GameObject.Find("character").GetComponent<playerHealth>().health / 100;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Healthadding.SetActive(true);
        HeadAddingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestoryHealthAdding()
    {
        yield return new WaitForSeconds(1);
        Healthadding.SetActive(false);
    }
}
