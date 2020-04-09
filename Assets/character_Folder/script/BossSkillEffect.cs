using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillEffect : MonoBehaviour
{
    private float speed = 2f;
    private Transform player;
    private Vector3 playerPos;
    public GameObject fireball;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if(player != null)
        {
            //GameObject ballInstantiate = Instantiate(fireball, transform) as GameObject;
            transform.position += transform.forward * (speed * Time.deltaTime);
            transform.LookAt(player);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPos - transform.position), 1);
        }
        //particle.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerPos - transform.position), 1);
        //particle.transform.position += transform.forward * (speed * Time.deltaTime);
    }
}
