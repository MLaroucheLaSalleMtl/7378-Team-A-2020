using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatPortal : MonoBehaviour
{
    public GameObject defeafPanel;
    public static bool GameIsPause = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            defeafPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            Time.timeScale = 0f;
            GameIsPause = true;
        }
    }
}
