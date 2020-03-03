using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;//declare the item type
    public string description;
    public Sprite icon;
    public bool pickedUp;

    //[HideInInspector]
    //public bool equipped;
    //public GameObject weapon;
    //public GameObject weaponManager;

    //public bool playersWeapon;

    [HideInInspector]
    public bool drunk;
    public GameObject potion;
    public GameObject potionManager;
    
    public void ItemUsage()
    {
        //Health potion
        if (type == "HPP")
        {
            drunk = true;
        }
        //Weapon
        //if (type == "Weapon")
        //{
        //    equipped = true;
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        //weaponManager = GameObject.FindWithTag("weaponManager");
        //if (!playersWeapon)
        //{

        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (drunk)
        {
            //show drinking effects
        }
        //if (equipped)
        //{
        //    //no need to show weapon change
        //}
    }
}
