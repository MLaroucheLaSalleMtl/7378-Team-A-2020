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

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (drunk)
        {
            //show drinking effects
        }
    }
}
