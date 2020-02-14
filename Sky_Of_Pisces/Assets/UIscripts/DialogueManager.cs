using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
   
    public Text dialogueText;
    public GameObject dialogueBox;
    private FreeLookCam fc;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

   
    public void StartDialogue(Dialogue dialogue)
    {
        print("Staring" + dialogue.NPCname);
        
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
           
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        FreeLookCam.OnDialogue = false;
        print("End");
        dialogueBox.SetActive(false);
        player.GetComponent<ThirdPersonUserControl>().enabled = true;
        //Time.timeScale = 1f;
    }
}
