using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerForBoss : MonoBehaviour
{
    public Transform BossZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("BossScene");
            other.gameObject.transform.position = BossZone.position;
        }
    }
}
