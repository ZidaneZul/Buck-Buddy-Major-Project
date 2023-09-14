using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class DisplayFoodItems : MonoBehaviour
{
    public GameObject textDisplay,smallerTextDisplayer, listContent, listSmallerContent;

    public List<string> spawnedItemBubble = new List<string>();

    string itemTxt;
    // Start is called before the first frame update
    void Start()
    {
        ShowItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowItems()
    {
        Debug.Log("Showing items");
        storeCartData storedCartData = GameObject.Find("RandomEventHandler").GetComponent<storeCartData>();
        foreach (var item in storedCartData.data)
        {
            GameObject displayedSamllerItems = Instantiate(smallerTextDisplayer, listSmallerContent.transform);
            var smallerItemPrice = displayedSamllerItems.transform.Find("Price").GetComponent<Text>();
            var smallerItemName = displayedSamllerItems.transform.Find("ItemName").GetComponent<Text>();

            itemTxt = item.name;
            itemTxt = string.Concat(itemTxt.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');

            smallerItemName.text = itemTxt;
            smallerItemPrice.text ="$" + item.price.ToString("F2");
        
            Debug.LogWarning("AMOUNT OF ITEM IN CARTDATA" + storedCartData.cartData.Count);
            foreach (KeyValuePair<string, int> cart in storedCartData.cartData)
            {
                Debug.Log("going thru cart");
                if (cart.Key == item.itemName && !spawnedItemBubble.Contains(item.itemName))
                {
                    spawnedItemBubble.Add(item.itemName);
                    GameObject displayedItem = Instantiate(textDisplay, listContent.transform);

                    var itemQuantity = displayedItem.transform.Find("Quantity").GetComponent<Text>();
                    var itemName = displayedItem.transform.Find("FoodName").GetComponent<Text>();
                    var itemPrice = displayedItem.transform.Find("Price").GetComponent<Text>();


                    itemName.text = cart.Key;
                    itemPrice.text = "$" + item.price.ToString("F2");

                    itemQuantity.text = cart.Value + "x";
                }
            }
        }
    }
}
