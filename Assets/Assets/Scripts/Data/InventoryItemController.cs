using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
    public ItemData item;

    public Button removeButton;

    public TextMeshProUGUI quantityTxt;

    int quantity;

    bool getItemQuantity;
    private void Start()
    { 
        removeButton = GetComponentInChildren<Button>();
        quantityTxt = GameObject.Find("Quantity_Txt").GetComponent<TextMeshProUGUI>();
    }

    public void RemoveOne()
    {

        Debug.Log(item.name);
        Debug.Log(gameObject);
        foreach (KeyValuePair<int, int> pair in InventoryManager.Instance.duplicateCounts)
        {
            Debug.Log("Going thru dictionary");
            if (pair.Key == item.id)
            {
                if (!getItemQuantity)
                {
                    quantity = pair.Value;
                    getItemQuantity = true;
                }

                Debug.Log("Found the id in dic");

                InventoryManager.Instance.Remove(item);

                quantity--;

                 quantityTxt.text = quantity + "x";
                Debug.Log("quantity var is +" + quantity);
                Debug.Log("pair value is +" + pair.Value);
                // AFTER DELETING ONE, NEVER UPDATE THE VALUES PLS FIX.

                if (quantity <= 0)
                {
                    Debug.Log("Deleting from list" + gameObject);
                    Destroy(gameObject);
                }
            }

        }


    }

    public void AddItem(ItemData newItem)
    {
        item = newItem;
    }
}
