using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anybutton : MonoBehaviour
{
    [SerializeField] private AudioSource PressAudio;

    // Start is called before the first frame update
    void Start()
    {
        PressAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            PressAudio.Play();
            SceneManager.LoadScene("UI");
        }
    }
}
