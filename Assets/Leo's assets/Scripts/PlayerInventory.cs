using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inv;
    private bool inventoryEnabled;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled == true)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
    
}
