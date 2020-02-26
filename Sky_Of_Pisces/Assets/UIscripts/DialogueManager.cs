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

    //Open the different portal
    public GameObject EaglePortal;
    public GameObject BandgerPortal;
    public GameObject AntPortal;

    //To show different path arrow
    //public GameObject Arrow;
    //[SerializeField] private Transform Eagle;
    //[SerializeField] private Transform Ant;
    //[SerializeField] private Transform Badger;

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
        //To show the arrow panel
        //Arrow.SetActive(true);

        //To identify which npc will lead to different conditions
        if (id == 1)
        {
            questText.text = "Kill the 5 dragons" ;
            EaglePortal.SetActive(true);

            //Vector3 targetPos = Eagle.transform.position;
            //targetPos.y = transform.position.y;
            //transform.LookAt(targetPos);

        }
        if (id == 2)
        {
            questText.text = "11";
            BandgerPortal.SetActive(true);
            
            //Vector3 targetPos = Ant.transform.position;
            //targetPos.y = transform.position.y;
            //transform.LookAt(targetPos);
        }
        if (id == 3)
        {
            questText.text = "22";
            AntPortal.SetActive(true);
           
            //Vector3 targetPos = Badger.transform.position;
            //targetPos.y = transform.position.y;
            //transform.LookAt(targetPos);
        }
        
        


        
    }
}
