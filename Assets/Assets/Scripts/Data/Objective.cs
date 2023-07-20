using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    public ObjectiveData objectiveData;

    public GameObject textPrefab, shoppingListContent;
    // Start is called before the first frame update
    void Start()
    {
        ShoppingListDisplay();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void ShoppingListDisplay()
    {
        

        if(objectiveData.Soup > 0)
        {
            Debug.Log("Soup Needed: " + objectiveData.Soup);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Soup ";
            itemQuantity.text = objectiveData.Soup + "x";
        }

        if (objectiveData.Lettuce > 0)
        {
            Debug.Log("Lettuce Needed: " + objectiveData.Lettuce);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Lettuce ";
            itemQuantity.text = objectiveData.Lettuce + "x";
        }

        if (objectiveData.Cheese > 0)
        {
            Debug.Log("Cheese Needed: " + objectiveData.Cheese);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Cheese ";
            itemQuantity.text = objectiveData.Cheese + "x";
        }
        if (objectiveData.Tomatoes > 0)
        {
            Debug.Log("Tomatoes Needed: " + objectiveData.Tomatoes);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Tomatoes ";
            itemQuantity.text = objectiveData.Tomatoes + "x";
        }
        if (objectiveData.Noodles > 0)
        {
            Debug.Log("Noodles Needed: " + objectiveData.Noodles);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Noodeles ";
            itemQuantity.text = objectiveData.Noodles + "x";
        }
        if (objectiveData.Eggs > 0)
        {
            Debug.Log("Eggs Needed: " + objectiveData.Eggs);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Eggs ";
            itemQuantity.text = objectiveData.Eggs + "x";
        }
        if (objectiveData.Bread > 0)
        {
            Debug.Log("Bread Needed: "+objectiveData.Bread);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Bread ";
            itemQuantity.text = objectiveData.Bread + "x";
        }
        if (objectiveData.Mushrooms > 0)
        {
            Debug.Log("Mushrooms Needed: " + objectiveData.Mushrooms);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Mushrooms ";
            itemQuantity.text = objectiveData.Mushrooms + "x";
        }
        if (objectiveData.Meat > 0)
        {
            Debug.Log("Meat Needed: " + objectiveData.Meat);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Meat ";
            itemQuantity.text = objectiveData.Meat + "x";
        }
        if (objectiveData.SoySauce > 0)
        {
            Debug.Log("SoySauce Needed: " + objectiveData.SoySauce);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "SoySauce ";
            itemQuantity.text = objectiveData.SoySauce + "x";
        }
        if (objectiveData.Ham > 0)
        {
            Debug.Log("Ham Needed: " + objectiveData.Ham);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Ham ";
            itemQuantity.text = objectiveData.Ham + "x";
        }
    }
}
