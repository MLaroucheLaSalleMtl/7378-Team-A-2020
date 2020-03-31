using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest Object", menuName = "Inventory System/Item/Quest")]
public class QuestObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Quest;
    }
}
