using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image DeadBackground;
    public Image DialogueBox;
    public Image ContinueButton;

    // Start is called before the first frame update
    void Start()
    {
        DeadBackground.canvasRenderer.SetAlpha(0.0f);
        DialogueBox.canvasRenderer.SetAlpha(0.0f);
        ContinueButton.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
    }

    void fadeIn()
    {
        DeadBackground.CrossFadeAlpha(1, 2, false);
        DialogueBox.CrossFadeAlpha(1, 2, false);
        ContinueButton.CrossFadeAlpha(1, 2, false);
    }
}
