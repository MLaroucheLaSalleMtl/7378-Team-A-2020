using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostForest : MonoBehaviour
{
    public AudioSource GhostForestMusic;
    
    public Text TownName;
    public Image TownNameBorder;

    // Start is called before the first frame update
    void Start()
    {
        GhostForestMusic = GetComponent<AudioSource>();
        TownName.canvasRenderer.SetAlpha(0.0f);
        TownNameBorder.canvasRenderer.SetAlpha(0.0f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GhostForestMusic.Play();
            GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Stop();
            fadeIn();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GhostForestMusic.Stop();
            GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Play();
            fadeOut();
        }

    }

    void fadeOut()
    {
        TownName.CrossFadeAlpha(0, 2, false);
        TownNameBorder.CrossFadeAlpha(0, 2, false);
    }

    void fadeIn()
    {
        TownName.CrossFadeAlpha(1, 2, false);
        TownNameBorder.CrossFadeAlpha(1, 2, false);
    }
}
