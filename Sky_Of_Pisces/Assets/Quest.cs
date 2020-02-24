using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject QuestPanel;
    public GameObject TalkPanel;
    public AudioSource NpcVoice;

    public static bool GameIsPause = false;


    // Start is called before the first frame update
    void Start()
    {
        NpcVoice = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC2")
        {
            
            TalkPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                TalkPanel.SetActive(false);
                QuestPanel.SetActive(true);
                NpcVoice.Play();

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                GameIsPause = true;
            }
        }

    }

    public void GoReturn()
    {

        QuestPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
}
