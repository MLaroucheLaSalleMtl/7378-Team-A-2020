using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public GameObject player;
    public Animator anim;

    private FreeLookCam fc;
    private bool reset = false;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(true);
            FreeLookCam.OnDialogue = true;
                if (!reset)
                {                
                    anim.SetFloat("Forward", 0);
                    reset = true;
                }
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                player.GetComponent<ThirdPersonUserControl>().enabled = false;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);                   
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        reset = false;
        
    }

    //public void TriggerDialogue()
    //{
    //    FindObjectOfType<DialogueManager>().StartDialogue(dislogue);
    //}
}
