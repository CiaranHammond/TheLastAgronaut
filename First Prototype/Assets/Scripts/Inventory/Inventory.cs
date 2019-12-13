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
    public int i = 0;
    public List<Item> items = new List<Item>();

    public Vector2[] itemsList = new Vector2[3];

    Vector2 milk = new Vector2(1, 0);
    Vector2 cut = new Vector2(2, 0);
    Vector2 med = new Vector2(3, 0);

    public bool Add(Item item)
    {
        itemsList[0] = milk;
        itemsList[1] = cut;
        itemsList[2] = med;

        
        for (i = 0; i < itemsList.Length; i++)
        {
            if(itemsList[i].x == 1)
            {
                //Debug.Log(itemsList[i].y);
                itemsList[i].y += 1;
                //Debug.Log(itemsList[i].y);
                items.Add(item);
                break;
            }
            if (itemsList[i].x == 2)
            {
                //Debug.Log(itemsList[i].y);
                itemsList[i].y += 1;
                //Debug.Log(itemsList[i].y);
                items.Add(item);
                break;
            }
            if (itemsList[i].x == 3)
            {
                //Debug.Log(itemsList[i].y);
                itemsList[i].y += 1;
                //Debug.Log(itemsList[i].y);
                items.Add(item);
                break;
            }
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
