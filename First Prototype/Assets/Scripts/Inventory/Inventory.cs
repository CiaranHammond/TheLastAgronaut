using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 3;
    public int milkTotal = 0;
    public int cuttingsTotal = 0;
    public int medTotal = 0;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;//this bool is to not destroy the gameObject if out of room
        }

        if(item.name == "Milk")
        {
            if (milkTotal == 0)
            {
                items.Add(item);
                milkTotal += 1;
            }
            else if(milkTotal>0)
            {
                Debug.Log("Too much milk!");
                return false;
            }
        }
        else if (item.name == "Cutting")
        {
            if (cuttingsTotal == 0)
            {
                items.Add(item);
                cuttingsTotal += 1;
            }
            else if (cuttingsTotal > 0)
            {
                Debug.Log("Too many cuttings!");
                return false;
            }
        }
        else if (item.name == "Medicine")
        {
            if (medTotal == 0)
            {
                items.Add(item);
                medTotal += 1;
            }
            else if (medTotal > 0)
            {
                Debug.Log("Too much medicine!");
                return false;
            }
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return true;//this bool is to destroy the gameObject - i.e added to inv
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
