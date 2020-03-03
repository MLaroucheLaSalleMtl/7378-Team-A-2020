using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{//bridge combine item components and slot components

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

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }
    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDsc, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                //add in item to slot
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDsc;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;//to move transform of game object itself which is the item we picking up
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
            }  
        }
        return;
    }
}
