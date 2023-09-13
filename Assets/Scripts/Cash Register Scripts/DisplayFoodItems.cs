using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFoodItems : MonoBehaviour
{
    public GameObject textDisplay, listContent;
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
            Debug.Log("goin thru item");
            Debug.Log(storedCartData.cartData.Count);
            foreach (KeyValuePair<string, int> cart in storedCartData.cartData)
            {
                Debug.Log("going thru cart");
                if (cart.Key == item.itemName)
                {
                    Debug.Log("MAKING ITEMS DISPLAY");
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
