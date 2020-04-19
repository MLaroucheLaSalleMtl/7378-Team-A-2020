using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion Object", menuName = "Inventory System/Item/Potion")]
public class EnergyPotionObject : ItemObject
{
    public int restoreEnergyValue;
    public void Awake()
    {
        type = ItemType.Potion;
    }
}
