using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    private GameObject boss;
    private bool isShooting;
    private bool isFlying;
    private Rigidbody rig;
    private Transform player;
    private playerHealth playerHP;
    private float damage = 15;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        rig = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHP = player.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        setFire();
        if (isShooting)
        {
            transform.localPosition += transform.forward * (18 * Time.deltaTime);
            //Vector3 pos = transform.localScale;
            //rig.AddForce(pos * 0.1f, ForceMode.Impulse);
            //Vector3 target = player.position;
            //rig.velocity = transform.forward * 20;
            //transform.Translate(target, Space.Self);
            //transform.position = Vector3.MoveTowards(transform.position, target, 10);
            //rig.AddRelativeForce(transform.forward * 0.1f, ForceMode.Impulse);
        }
    }

    void setFire()
    {
        if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FireballShoot"))
        {
            isShooting = true;
            isFlying = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHP.takeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }
}
