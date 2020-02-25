using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public Item itemAdded;
    public int i = 0, j = 0, k = 0, l = 0, m = 0;
    public List<Item> items = new List<Item>();
    public Dictionary<int, Item> milkDictionary = new Dictionary<int, Item>();
    public Dictionary<int, Item> medDictionary = new Dictionary<int, Item>();
    public Dictionary<int, Item> cutDictionary = new Dictionary<int, Item>();
    public Dictionary<int, Item> amm1Dictionary = new Dictionary<int, Item>();
    public Dictionary<int, Item> amm2Dictionary = new Dictionary<int, Item>();



    public bool Add(Item item)
    {
        if(item != null)
        {
            if (item.name == "Milk")
            {
                itemAdded = item;
                milkDictionary.Add(i, item);
                i++;

                items.Add(item);
            }
            else if (item.name == "Medicine")
            {
                itemAdded = item;
                medDictionary.Add(j, item);
                j++;

                items.Add(item);
            }
            else if (item.name == "Cutting")
            {
                itemAdded = item;
                cutDictionary.Add(k, item);
                k++;

                items.Add(item);
            }
            else if(item.name == "Ammo1")
            {
                itemAdded = item;
                amm1Dictionary.Add(l, item);
                l++;

                items.Add(item);
            }
            else if (item.name == "Ammo2")
            {
                itemAdded = item;
                amm2Dictionary.Add(m, item);
                m++;

                items.Add(item);
            }
        }
        else
        {
            Debug.Log("Null Item???");
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return true;//this bool is to destroy the gameObject - i.e added to inv
    }

    public void Remove(Item item)
    {
        if(item.name == "Milk")
        {
            milkDictionary.Remove(i);
            i--;
            items.Remove(item);
        }
        else if (item.name == "Medicine")
        {
            medDictionary.Remove(j);
            j--;
            items.Remove(item);
        }
        else if (item.name == "Cutting")
        {
            cutDictionary.Remove(k);
            k--;
            items.Remove(item);
        }
        else if (item.name == "Ammo1")
        {
            amm1Dictionary.Remove(l);
            l--;
            items.Remove(item);
        }
        else if (item.name == "Ammo2")
        {
            amm2Dictionary.Remove(m);
            m--;
            items.Remove(item);
        }

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
