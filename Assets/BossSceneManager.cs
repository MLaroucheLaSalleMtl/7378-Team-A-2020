using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSceneManager : MonoBehaviour
{
    public GameObject BossInfo;
    public AudioSource BattleMusic;
    public Transform player;

    public CameraShake camerShake;

    private void Start()
    {
        BattleMusic = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 50f)
        {
            BossInfo.SetActive(true);
            BattleMusic.Play();

            StartCoroutine(camerShake.Shake(.50f, .5f));


        }

    } 
}
