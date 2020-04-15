using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    private GameObject boss;
    private bool isShooting;
    private bool isFlying;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        setFire();
        if (isShooting)
        {
            transform.position += transform.forward * (10 * Time.deltaTime);
        }else if (isFlying)
        {
            //Vector3 fireDirection = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 1f);
            //transform.position = Vector3.MoveTowards(transform.position, fireDirection, 5 * Time.deltaTime);
        }
    }

    void setFire()
    {
        if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FireballShoot"))
        {
            isShooting = true;
            isFlying = false;
        }
        else if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FlyFireballShoot"))
        {
            isShooting = false;
            isFlying = true;
        }
    }
}
