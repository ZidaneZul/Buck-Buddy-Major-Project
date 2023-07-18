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

    public GameObject shoppingCartPanel;

    int quantity;

    bool didGetQuantitiyValue = false;
    private void Start()
    { 
        removeButton = GetComponentInChildren<Button>();
        //quantityTxt = GameObject.Find("Quantity_Txt").GetComponent<TextMeshProUGUI>();
        shoppingCartPanel = GameObject.Find("Cart_Panel");
    }
    public void Update()
    {

        //if (shoppingCartPanel.activeInHierarchy && !didGetQuantitiyValue)
        //{
        //    foreach (KeyValuePair<int, int> pair in InventoryManager.Instance.duplicateCounts)
        //    {
        //        if(pair.Key == item.id)
        //        {
        //            quantity = pair.Value;
        //            didGetQuantitiyValue=true;
        //        }
        //    }
        //    quantityTxt.text = quantity + "x";
        //    Debug.Log("Cart is open in the inventory item controller");
        //}
        //else if (!shoppingCartPanel.activeInHierarchy)
        //{
        //    didGetQuantitiyValue = false ;
        //    Debug.Log("the cart is closed (inventory item controller)");
        //}
        //InventoryManager.Instance.ShowItem();
    }

    public void RemoveOne()
    {

        //Debug.Log(item.name);
        Debug.Log(gameObject);
        //foreach (KeyValuePair<int, int> pair in InventoryManager.Instance.duplicateCounts)
        //{
        //    Debug.Log("Going thru dictionary"); 
        //    if (pair.Key == item.id)
        //    {
        //Debug.Log("Found the id in dic" + quantity);

        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);

        //quantity -= 1;


        // AFTER DELETING ONE, NEVER UPDATE THE VALUES PLS FIX.

        //    }
        //    //quantityTxt.text = quantity + "x";
        //    //Debug.Log("quantity var is +" + quantity);
        //    //Debug.Log("pair value is +" + pair.Value);
        //}
    }
    
    public void AddItem(ItemData newItem)
    {
        item = newItem;
    }
}
