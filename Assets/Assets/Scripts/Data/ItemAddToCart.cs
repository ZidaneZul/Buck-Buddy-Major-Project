using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemAddToCart : MonoBehaviour
{
    ItemController itemController;
    ItemData itemData;
    Vector3 boxSize = new Vector3(1.7f, 1.5f, 2);

    TextMeshProUGUI tmp;
    public GameObject PopOutNotif,dataToTake;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        GetFoodItemData();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Testing()
    {
        Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, boxSize);
        
        foreach (Collider collider in colliders)
        {
            if((collider.gameObject.GetComponent<ItemController>()) && (collider.gameObject.transform.position.x == gameObject.transform.position.x))
            {
                dataToTake = collider.gameObject;
            }
        }

    }
    void GetFoodItemData() 
    {
        Testing();

        //closeFood = closePoint.transform.GetChild(0).gameObject;
        itemController = dataToTake.GetComponent<ItemController>();
        itemData = itemController.item;

        //Debug.Log("the item data for food thats close is "+ item.ToString());
       Debug.Log("The close food in the bubble script is " + itemData.itemName);

        tmp.text = itemData.itemName + "\n" + "$" + itemData.price.ToString("F2");
    }

    public void AddToCart()
    {
        InventoryManager.Instance.Add(itemData);
        Vector3 PopOutOffset = new Vector3(transform.position.x, transform.position.y + 4.5f, transform.position.z);
        GameObject points = Instantiate(PopOutNotif, PopOutOffset, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = "+1 " + itemData.itemName + " $" + itemData.price.ToString("F2");
        Debug.Log("Added " + itemData + " to cart");
    }
}
