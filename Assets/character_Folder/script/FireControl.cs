using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    private GameObject boss;
    private bool isShooting;
    private bool isFlying;
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        setFire();
        if (isShooting)
        {
            //transform.position += transform.forward * (5 * Time.deltaTime);
            rig.AddForce(transform.forward * 0.1f, ForceMode.Impulse);
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
}
