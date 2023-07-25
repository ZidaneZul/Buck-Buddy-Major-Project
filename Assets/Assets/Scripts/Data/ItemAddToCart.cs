using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemAddToCart : MonoBehaviour
{
    ItemController itemController;
    ItemData itemData;

    TextMeshProUGUI tmp;

    GameObject[] foodPoint;
    GameObject closePoint, closeFood, closeText;

    // Start is called before the first frame update
    void Start()
    {
        foodPoint = GameObject.FindGameObjectsWithTag("FoodSpawn");
        tmp = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        FindCloseFood();
    }

    void FindCloseFood()
    {
        foreach (GameObject point in foodPoint) 
        {
            if (Vector3.Distance(transform.position, point.transform.position) < 3) 
            {
                closePoint = point;
                GetFoodItemData();
            }

        }
    }
    void GetFoodItemData() 
    { 
        closeFood = closePoint.transform.GetChild(0).gameObject;
        itemController = closeFood.GetComponent<ItemController>();
        itemData = itemController.item;

        //Debug.Log("the item data for food thats close is "+ item.ToString());
       // Debug.Log("The close food in the bubble script is " + itemData.itemName);

        tmp.text = itemData.itemName + "\n" + "$" + itemData.price.ToString("F2");
    }

    public void AddToCart()
    {
        InventoryManager.Instance.Add(itemData);
        Debug.Log("Added " + itemData + " to cart");
    }
}
