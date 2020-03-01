using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private bool inventoryEnabled;
    public GameObject inventory;//state inventory as a game object

    private int allSlots;
    private GameObject[] slot;//single instance for each slot variable, so it has to be an array

    public GameObject slotCage;//state slotCage as a game object

    void Start()
    {
        allSlots = 9 * 5;//number of slots
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {//get the game object's child transformation, reach slot as a game object type
            slot[i] = slotCage.transform.GetChild(i).gameObject;
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {//make sure it switches between enabled and unenabled (open and close)
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled == true)
        {//if inventory is not opened, this makes sure to open the inventory
            inventory.SetActive(true);
        }
        else
        {//if inventory is not closed, this makes sure to close the inventory
            inventory.SetActive(false);
        }
    }
}
