using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public class DialogueManager : MonoBehaviour
{
    public static int id = 0;
    //Dialogue 
    private Queue<string> sentences;   
    public Text dialogueText;
    public GameObject dialogueBox;
    private FreeLookCam fc;
    public GameObject player;
    
    // To show Quest at the left top
    public GameObject Quest;
    public Text questText;
    public GameObject Pointer;
   

    //Open the different portal
    public GameObject EaglePortal;
    public GameObject BandgerPortal;
    public GameObject AntPortal;

    //Eliminate the quest mark
    public GameObject Exclamation1;
    public GameObject Exclamation2;
    public GameObject Exclamation3;
    public GameObject QuestionMark;

    //enemy spawner    
    
    

    // Start is called before the first frame update   
    private void Awake()
    {
        sentences = new Queue<string>();
    }
   
    public void StartDialogue(Dialogue dialogue)
    {
       
        Quest.SetActive(false);
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
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
        GameObject.FindWithTag("Player").GetComponent<Animator>().enabled = true;
        dialogueBox.SetActive(false);
        player.GetComponent<ThirdPersonUserControl>().enabled = true;
        
        //To show the quest panel
        Quest.SetActive(true);
      
        //To identify which npc will lead to different conditions
        if (id == 1)
        {
            questText.text = "Kill the 2 Monsters to acquire a skill";
            EaglePortal.SetActive(true);
            BandgerPortal.SetActive(false);
            AntPortal.SetActive(false);
            Exclamation1.SetActive(false);

        }
        if (id == 2)
        {
           
            questText.text = "Defeat this huge Monster and get a potion";
            BandgerPortal.SetActive(true);
            AntPortal.SetActive(false);
            EaglePortal.SetActive(false);
            Exclamation2.SetActive(false);
            
        }
        if (id == 3)
        {
            questText.text = "Kill 3 monsters";
            AntPortal.SetActive(true);
            EaglePortal.SetActive(false);
            BandgerPortal.SetActive(false);
            Exclamation3.SetActive(false);
        }

        if (id == 4)
        {
            questText.text = "Trigger the boss";
            Pointer.SetActive(true);
            QuestionMark.SetActive(false);
        }
        
        
    }

   
}
