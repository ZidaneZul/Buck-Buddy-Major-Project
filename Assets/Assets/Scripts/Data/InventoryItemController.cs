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

    public bool getItemQuantity;
    private void Start()
    { 
        removeButton = GetComponentInChildren<Button>();
        quantityTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        //Debug.Log(getItemQuantity);
    }

    public void RemoveOne()
    {
        foreach (KeyValuePair<string, int> pair in InventoryManager.Instance.duplicateCounts)
        {
            Debug.Log("Going thru dictionary");
            if (pair.Key == item.itemName)
            {
                if (!getItemQuantity)
                {
                    quantity = pair.Value;
                    getItemQuantity = true;
                }

               // Debug.Log("Found the id in dic");

                InventoryManager.Instance.Remove(item);

                quantity--;

                 quantityTxt.text = quantity + "x";
                if (quantity <= 0)
                {
                    Objective.Instance.ChangeItemDataBoolValue(item.itemType);
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
