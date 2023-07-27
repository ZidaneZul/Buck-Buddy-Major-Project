using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    public static Objective Instance;
    
    public ObjectiveData objectiveData;

    public GameObject textPrefab, shoppingListContent;

    public string objListString;

    public List<KeyValuePair<string, int>> objList = new List<KeyValuePair<string, int>>();

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ShoppingListDisplay();
       foreach(KeyValuePair<string, int> obj in objList)
        {
            Debug.Log("Require food type is " + obj.Key + " " + obj.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(objListString);
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

            for (int i = 0; i < objectiveData.Soup; i++)
            {
                objListString += "soup";
            }
            objList.Add(new KeyValuePair<string, int>("Soup", objectiveData.Soup));
        }

        if (objectiveData.Lettuce > 0)
        {
            Debug.Log("Lettuce Needed: " + objectiveData.Lettuce);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Lettuce ";
            itemQuantity.text = objectiveData.Lettuce + "x";

            for (int i = 0; i < objectiveData.Lettuce; i++)
            {
                objListString += "lettuce";
            }
            objList.Add(new KeyValuePair<string, int>("Lettuce", objectiveData.Lettuce));

        }

        if (objectiveData.Cheese > 0)
        {
            Debug.Log("Cheese Needed: " + objectiveData.Cheese);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Cheese ";
            itemQuantity.text = objectiveData.Cheese + "x";

            for (int i = 0; i < objectiveData.Cheese; i++)
            {
                objListString += "cheese";
            }
            objList.Add(new KeyValuePair<string, int>("Cheese", objectiveData.Cheese));

        }
        if (objectiveData.Tomatoes > 0)
        {
            Debug.Log("Tomatoes Needed: " + objectiveData.Tomatoes);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Tomatoes ";
            itemQuantity.text = objectiveData.Tomatoes + "x";

            for (int i = 0; i < objectiveData.Tomatoes; i++)
            {
                objListString += "tomatoes";
            }
            objList.Add(new KeyValuePair<string, int>("Tomatoes", objectiveData.Tomatoes));

        }
        if (objectiveData.Noodles > 0)
        {
            Debug.Log("Noodles Needed: " + objectiveData.Noodles);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Noodeles ";
            itemQuantity.text = objectiveData.Noodles + "x";

            for (int i = 0; i < objectiveData.Noodles; i++)
            {
                objListString += "noodles";
            }
            objList.Add(new KeyValuePair<string, int>("Noodles", objectiveData.Noodles));

        }
        if (objectiveData.Eggs > 0)
        {
            Debug.Log("Eggs Needed: " + objectiveData.Eggs);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Eggs ";
            itemQuantity.text = objectiveData.Eggs + "x";

            for (int i = 0; i < objectiveData.Eggs; i++)
            {
                objListString += "eggs";
            }
            objList.Add(new KeyValuePair<string, int>("Eggs", objectiveData.Eggs));

        }
        if (objectiveData.Bread > 0)
        {
            Debug.Log("Bread Needed: "+objectiveData.Bread);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Bread ";
            itemQuantity.text = objectiveData.Bread + "x";

            objList.Add(new KeyValuePair<string, int>("Bread", objectiveData.Bread));


            for (int i = 0; i < objectiveData.Bread; i++)
            {
                objListString += "bread";
            }
        }
        if (objectiveData.Mushrooms > 0)
        {
            Debug.Log("Mushrooms Needed: " + objectiveData.Mushrooms);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Mushrooms ";
            itemQuantity.text = objectiveData.Mushrooms + "x";

            for (int i = 0; i < objectiveData.Mushrooms; i++)
            {
                objListString += "mushrooms";
            }
            objList.Add(new KeyValuePair<string, int>("Mushrooms", objectiveData.Mushrooms));

        }
        if (objectiveData.Meat > 0)
        {
            Debug.Log("Meat Needed: " + objectiveData.Meat);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Meat ";
            itemQuantity.text = objectiveData.Meat + "x";

            for (int i = 0; i < objectiveData.Meat; i++)
            {
                objListString += "meat";
            }
            objList.Add(new KeyValuePair<string, int>("Meat", objectiveData.Meat));

        }
        if (objectiveData.SoySauce > 0)
        {
            Debug.Log("SoySauce Needed: " + objectiveData.SoySauce);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "SoySauce ";
            itemQuantity.text = objectiveData.SoySauce + "x";

            for (int i = 0; i < objectiveData.SoySauce; i++)
            {
                objListString += "soysauce";
            }
            objList.Add(new KeyValuePair<string, int>("SoySauce", objectiveData.SoySauce));

        }
        if (objectiveData.Ham > 0)
        {
            Debug.Log("Ham Needed: " + objectiveData.Ham);

            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

            itemName.text = "Ham ";
            itemQuantity.text = objectiveData.Ham + "x";

            for (int i = 0; i < objectiveData.Ham; i++)
            {
                objListString += "ham";
            }
            objList.Add(new KeyValuePair<string, int>("Ham", objectiveData.Ham));

        }
    }
}
