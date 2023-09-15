using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class Objective : MonoBehaviour
{
    public static Objective Instance;

    public ObjectiveData objectiveData;

    public GameObject textPrefab, dynamicTextPrefab, shoppingListContent, dynamicShoppingListContent, dynamicShoppingList;
    public List<KeyValuePair<string, int>> objList = new List<KeyValuePair<string, int>>();
    public List<string> requiredAisleItems = new List<string>();

    public TextMeshProUGUI levelBudget_Txt;

    public MapLocation mapLocationSript;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ShoppingListDisplay();

        ShowBudget();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(GetCurrentAisleItem());
        
        if (mapLocationSript.DidPlayerChangeAisle())
        {
            SortShoppingList();
        }
    }

    public List<string> GetCurrentAisleItem()
    {
        requiredAisleItems.Clear();
        
        //get the first word of where the player is (Meat Seafood Aisle ==> Meat)
        string location = mapLocationSript.FindPlayer().Split(' ')[0];

        //Get a list of different item types in that aisle (Veggie aisle has "onion, lettuce, carrot etc")
        string[] aisleItemType = MapDataList.instance.GetAisleTypes(location);

        //goes thru the item type required for obj
        foreach (KeyValuePair<string, int> obj in objList)
        {
            //goes thru the diff item types in that aisle
            foreach (var aisleType in aisleItemType)
            {
                //if there is an item type obj there, run if statement
                if (obj.Key == aisleType)
                {
                    //Debug.LogWarning("Something is needed here");
                    //return the specific food type (lettuce / ham etc)
                    requiredAisleItems.Add(aisleType);
                }
            }
        }
        return requiredAisleItems;
    }




    public void SortShoppingList()
    {
        int ordernumber = 0;
        bool isSomethingHere = false;
        foreach (Transform obj in dynamicShoppingListContent.transform)
        {
            ObjectiveDataHolder objScript = obj.GetComponent<ObjectiveDataHolder>();
            objScript.isItemHere = false;

            foreach (string requireItemType in GetCurrentAisleItem())
            {
                if (objScript.typeOfItem == requireItemType && !objScript.sufficientAmount)
                {
                    obj.gameObject.SetActive(true);
                    obj.SetSiblingIndex(ordernumber);
                    ordernumber++;
                    objScript.isItemHere = true;
                    isSomethingHere = true;
                }
            }

            if (!objScript.isItemHere)
            {
                obj.gameObject.SetActive(false);
            }
            if (!isSomethingHere)
            {
                dynamicShoppingList.SetActive(false);
            }
            else
            {
                dynamicShoppingList.SetActive(true);
            }
        }

    }


    public void ShoppingListDisplay()
    {

        foreach (var obj in objectiveData.dynamicObjList)
        {
            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            GameObject dynamicShoppingListItem = Instantiate(dynamicTextPrefab, dynamicShoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();

            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();
            var dynItemQuantity = dynamicShoppingListItem.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();
           
            var itemSprite = shoppingListItems.transform.Find("FoodType_Img").GetComponent<Image>();
            var dynItemSprite = dynamicShoppingListItem.transform.Find("FoodType_Img").GetComponent<Image>();

            ObjectiveDataHolder dynamicObjDataHolder = dynamicShoppingListItem.GetComponent<ObjectiveDataHolder>();
            ObjectiveDataHolder objDataHolder = shoppingListItems.GetComponent<ObjectiveDataHolder>();

            itemName.text = obj.itemType;
            objDataHolder.typeOfItem = obj.itemType;
            dynamicObjDataHolder.typeOfItem = obj.itemType;

            itemQuantity.text = obj.amount.ToString();
            dynItemQuantity.text = "x" + obj.amount.ToString();
            dynamicObjDataHolder.quantity = obj.amount;
            objDataHolder.quantity = obj.amount;

            itemSprite.sprite = obj.iconSprite;
            dynItemSprite.sprite = obj.iconSprite;

            objList.Add(new KeyValuePair<string, int>(obj.itemType, obj.amount));
        }
    }

    public void ShowBudget()
    {
        levelBudget_Txt = GameObject.Find("LevelBudget_Txt").GetComponent<TextMeshProUGUI>();
        levelBudget_Txt.text = "Budget: $" + objectiveData.budget.ToString("F2");
    }

    public float GetBudget()
    {
        return objectiveData.budget;
    }

    public void ObjCheckOff()
    {
        foreach(Transform item in dynamicShoppingListContent.transform)
        {
            ObjectiveDataHolder itemDataHolder = item.GetComponent<ObjectiveDataHolder>();

            foreach (KeyValuePair<string, int> cartItems in InventoryManager.Instance.GetCartTypes())
            {
                Debug.Log(cartItems.Key == itemDataHolder.typeOfItem);
                if(cartItems.Key == itemDataHolder.typeOfItem)
                {
                    if (cartItems.Value >= itemDataHolder.quantity)
                    {
                        itemDataHolder.sufficientAmount = true;
                        Debug.Log("ENUF");
                        itemDataHolder.line.SetActive(true);
                    }
                }
            }
            if (!itemDataHolder.sufficientAmount)
            {
                itemDataHolder.sufficientAmount = false;
                itemDataHolder.line.SetActive(false);
            }
        }

        foreach (Transform item in shoppingListContent.transform)
        {
            ObjectiveDataHolder itemDataHolder = item.GetComponent<ObjectiveDataHolder>();

            foreach (KeyValuePair<string, int> cartItems in InventoryManager.Instance.GetCartTypes())
            {
                if (cartItems.Key == itemDataHolder.typeOfItem)
                {
                    if (cartItems.Value >= itemDataHolder.quantity)
                    {
                        itemDataHolder.sufficientAmount = true;
                        itemDataHolder.line.SetActive(true);
                    }
                }
            }
            if (!itemDataHolder.sufficientAmount)
            {
                itemDataHolder.sufficientAmount = false;
                itemDataHolder.line.SetActive(false);
            }
        }
    }

    public void ChangeItemDataBoolValue(string itemToReset)
    {
        Debug.Log("trying to find the error");
        foreach(Transform item in dynamicShoppingListContent.transform)
        {
            ObjectiveDataHolder itemDataHolder = item.GetComponent<ObjectiveDataHolder>();

            if (itemDataHolder.typeOfItem == itemToReset)
            {

                itemDataHolder.sufficientAmount = false;
                ObjCheckOff();
            }
        }
        foreach (Transform item in shoppingListContent.transform)
        {
            ObjectiveDataHolder itemDataHolder = item.GetComponent<ObjectiveDataHolder>();

            if (itemDataHolder.typeOfItem == itemToReset)
            {
                itemDataHolder.sufficientAmount = false;
                ObjCheckOff();
            }
        }
    }
}
