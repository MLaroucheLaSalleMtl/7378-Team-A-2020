using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FireballShoot"))
        {
            transform.position += transform.forward * (8 * Time.deltaTime);
        }else if (boss.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FlyFireballShoot"))
        {
            Vector3 fireDirection = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 1f);
            transform.position = Vector3.MoveTowards(transform.position, fireDirection, 5 * Time.deltaTime);
        }
    }
}
