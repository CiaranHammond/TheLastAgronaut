﻿using System.Collections;
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
    public Item itemAdded;
    public int space = 3;
    public int i = 0, j = 0, k = 0;
    public List<Item> items = new List<Item>();
    public Dictionary<int, Item> milkDictionary = new Dictionary<int, Item>();
    public Dictionary<int, Item> medDictionary = new Dictionary<int, Item>();
    public Dictionary<int, Item> cutDictionary = new Dictionary<int, Item>();

    

    public bool Add(Item item)
    {
        if(item.name == "Milk")
        {
            itemAdded = item;
            milkDictionary.Add(i, item);
            i++;
            
            items.Add(item);
        }
        if (item.name == "Medicine")
        {
            itemAdded = item;
            medDictionary.Add(j, item);
            j++;

            items.Add(item);
        }
        if (item.name == "Cutting")
        {
            itemAdded = item;
            cutDictionary.Add(k, item);
            k++;

            items.Add(item);
        }

               
        //if(items.Count >= space)
        //{
        //    Debug.Log("Not enough room");
        //    return false;//this bool is to not destroy the gameObject if out of room
        //}

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
