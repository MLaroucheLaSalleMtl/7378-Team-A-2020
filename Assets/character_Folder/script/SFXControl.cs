using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXControl : MonoBehaviour
{
    public AudioClip Lighting;
    public AudioClip PowerUp;
    private AudioSource audio;
    private playerAttack attack;
    // Start is called before the first frame update
    void Start()
    {
        attack = GameObject.Find("character").GetComponent<playerAttack>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attack.canPlayLighting)
        {
            audio.PlayOneShot(Lighting);
        }else if (attack.canPlayPowerup)
        {
            audio.PlayOneShot(PowerUp);
        }
    }
}
