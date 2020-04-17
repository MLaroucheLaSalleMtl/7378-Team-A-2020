using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss_State
{
    sleep,
    run,
    attack,
    skill,
    death
}

public class BossState : MonoBehaviour
{
    private Transform player;
    private Boss_State state = Boss_State.sleep;
    private enemyHealth bossHp;
    public int range;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossHp = GetComponent<enemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        //Debug.Log(range);
        if(state != Boss_State.death && bossHp.health < 1000)
        {
            if(distance <= 5)
            {
                state = Boss_State.attack;
            }
            else
            {
                state = Boss_State.run;
            }

        }
        if(bossHp.health <= 0)
        {
            state = Boss_State.death;
        }
    }

    public Boss_State Boss_State
    {
        get { return state; }
        set { Boss_State = value; }
    }
}
