using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;//declare the item type
    public string description;
    public bool empty;
    public Sprite icon;
    public Transform slotIconGO;
    // Start is called before the first frame update
    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
    public void UseItem()
    {

    }
    void Start()
    {
        slotIconGO = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
