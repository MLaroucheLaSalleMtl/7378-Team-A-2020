using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    public LayerMask enemyLayer;
    float radius = 6f;
    int damage = 15;

    //public GameObject damageArea;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach(Collider col in hit)
        {
            col.GetComponent<enemyHealth>().takeDamage(damage);
            enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
