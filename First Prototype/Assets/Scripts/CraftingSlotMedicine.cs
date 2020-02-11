using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlotMedicine : MonoBehaviour
{
    Inventory inventory = Inventory.instance;
    public Item item;

    void OnClick()
    {
        CraftMedicine(item);
        Debug.Log("clicked");
    }

    void CraftMedicine(Item item)
    {
        Debug.Log("here");
        if (inventory.i > 0 && inventory.k > 0)
        {
            inventory.Add(item);
        }
    }
}
