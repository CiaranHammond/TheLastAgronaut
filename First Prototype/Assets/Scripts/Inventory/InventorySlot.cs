using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text count;
    public int milkStack = 0;
    public int cuttingStack = 0;
    public int medStack = 0;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        if(item.name == "Milk")
        {
            Debug.Log("milk");
            milkStack += 1;
            count.text = milkStack.ToString();
        }
        else if(item.name == "Cutting")
        {
            Debug.Log("cutting");
            cuttingStack += 1;
        }
        else if(item.name == "Medicine")
        {
            Debug.Log("med");
            medStack += 1;
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
