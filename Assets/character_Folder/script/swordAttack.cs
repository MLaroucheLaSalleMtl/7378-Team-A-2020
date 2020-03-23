using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    //Collider[] touchEnemy = Physics.OverlapSphere(attackArea.position, attackRange, enemylayer);
    //foreach (Collider enemy in touchEnemy)
    //{
    //    if (anim.GetCurrentAnimatorStateInfo(0).IsName("slash1") || anim.GetCurrentAnimatorStateInfo(0).IsName("slash3") || anim.GetCurrentAnimatorStateInfo(0).IsName("slash4"))
    //    {
    //        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
    //        {
    //            enemy.GetComponent<enemyHealth>().takeDamage(damage);
    //        }
    //    }
    //}
}
