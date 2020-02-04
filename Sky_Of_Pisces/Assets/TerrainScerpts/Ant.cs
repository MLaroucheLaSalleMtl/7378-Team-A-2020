using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ant : MonoBehaviour
{
    public Text EagleName;
    public Image EagleNameBorder;
   
    // Start is called before the first frame update
    void Start()
    {
        EagleName.canvasRenderer.SetAlpha(0.0f);
        EagleNameBorder.canvasRenderer.SetAlpha(0.0f);
    }

    void fadeOut()
    {
        EagleName.CrossFadeAlpha(0, 2, false);
        EagleNameBorder.CrossFadeAlpha(0, 2, false);
    }

    void fadeIn()
    {
        EagleName.CrossFadeAlpha(1, 2, false);
        EagleNameBorder.CrossFadeAlpha(1, 2, false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeIn();

        }
    }

}
