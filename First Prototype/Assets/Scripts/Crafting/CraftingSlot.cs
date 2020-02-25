using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlot : MonoBehaviour
{
    public Inventory inventory;
    public Item med;
    public Item milk;
    public Item cut;
    public Item amm1;
    public Item amm2;


    public void CraftMedicine(Item med)
    {
        Debug.Log("here");
        Debug.Log("Item: " + med.name);
        if (inventory.i > 0 && inventory.k > 0)
        {
            inventory.Add(med);
            inventory.Remove(milk);
            inventory.Remove(cut);
        }
    }

    public void craftAmmo1(Item amm1)
    {
        if (inventory.k >= 2)
        {
            inventory.Add(amm1);
            inventory.Remove(cut);
            inventory.Remove(cut);
        }
    }

    public void craftAmmo2(Item amm2)
    {
        if (inventory.k >= 2)
        {
            inventory.Add(amm2);
            inventory.Remove(cut);
            inventory.Remove(cut);
        }
    }
}
