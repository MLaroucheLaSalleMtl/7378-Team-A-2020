using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eden : MonoBehaviour
{
    public Text EdenName;
    public Image EdenNameBorder;
    public AudioSource EdenMusic;

    // Start is called before the first frame update
    void Start()
    {
        EdenName.canvasRenderer.SetAlpha(0.0f);
        EdenNameBorder.canvasRenderer.SetAlpha(0.0f);
        EdenMusic = GetComponent<AudioSource>();
    }

    void fadeOut()
    {
        EdenName.CrossFadeAlpha(0, 2, false);
        EdenNameBorder.CrossFadeAlpha(0, 2, false);
    }

    void fadeIn()
    {
        EdenName.CrossFadeAlpha(1, 2, false);
        EdenNameBorder.CrossFadeAlpha(1, 2, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeIn();
            EdenMusic.Play();
            GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeOut();
            EdenMusic.Stop();
            GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Play();
        }
    }
}
