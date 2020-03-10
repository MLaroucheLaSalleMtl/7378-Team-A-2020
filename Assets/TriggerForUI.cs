using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerForUI : MonoBehaviour
{
    public GameObject DialoguePanel;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        DialoguePanel.SetActive(true);
        FindObjectOfType<DialogueForUI>().StartDialogue(dialogue);
    }

   
}
