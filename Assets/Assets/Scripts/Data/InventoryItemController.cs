using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
    public ItemData item;
    public void RemoveOne()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
    
    public void AddItem(ItemData newItem)
    {
        item = newItem;
    }
}
