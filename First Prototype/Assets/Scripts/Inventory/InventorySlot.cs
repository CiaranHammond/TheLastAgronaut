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
        count = FindObjectOfType<Text>();
        //count.text = "Count: ";
        if(item.name == "Milk")
        {
            milkStack += 1;
            count.text = milkStack.ToString();
            Debug.Log("milk" + count.text);
        }
        else if(item.name == "Cutting")
        {
            cuttingStack += 1;
            count.text = cuttingStack.ToString();
            Debug.Log("cut " + count.text);
        }
        else if(item.name == "Medicine")
        {
            medStack += 1;
            count.text = medStack.ToString();
            Debug.Log("med " + count.text);
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        count = FindObjectOfType<Text>();
        //count.text = "";
    }
}
