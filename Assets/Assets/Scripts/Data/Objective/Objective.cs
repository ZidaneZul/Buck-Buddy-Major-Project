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

    List<ObjectiveDataHolder> dynamicOBjList = new List<ObjectiveDataHolder>();
    ObjectiveDataHolder[] dynamicObj;

    public GameObject textPrefab, shoppingListContent, dynamicShoppingListContent;
    public List<KeyValuePair<string, int>> objList = new List<KeyValuePair<string, int>>();

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
        //foreach (KeyValuePair<string, int> obj in objList)
        //{
        //    Debug.Log("Require food type is " + obj.Key + " " + obj.Value);
        //}
        levelBudget_Txt = GameObject.Find("LevelBudget_Txt").GetComponent<TextMeshProUGUI>();

        ShowBudget();
        GetBudget();
        GetContentListType();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning(GetCurrentAisleItem());
        
        if (mapLocationSript.DidPlayerChangeAisle())
        {
            SortShoppingList();

        }
    }

    public string GetCurrentAisleItem()
    {
        //get the first word of where the player is (Meat Seafood Aisle ==> Meat)
        string location = mapLocationSript.FindPlayer().Split(' ')[0];
        Debug.Log(location);

        //Get a list of different item types in that aisle (Veggie aisle has "onion, lettuce, carrot etc")
        string[] aisleItemType = MapDataList.instance.GetAisleTypes(location);

        Debug.Log(objList.Count);
        //goes thru the item type required for obj
        foreach (KeyValuePair<string, int> obj in objList)
        {
            Debug.Log("help me");
            //goes thru the diff item types in that aisle
            foreach (var aisleType in aisleItemType)
            {
                Debug.Log(obj.Key + "\n" + aisleType);

                //if there is an item type obj there, run if statement
                if (obj.Key == aisleType)
                {
                    //Debug.LogWarning("Something is needed here");
                    //return the specific food type (lettuce / ham etc)
                    return aisleType;
                }
            }
        }
        return null;
    }

    public void GetContentListType()
    {
        dynamicObj = dynamicShoppingListContent.GetComponentsInChildren<ObjectiveDataHolder>();
        dynamicOBjList = dynamicObj.ToList();
    }

 
   
    public void SortShoppingList()
    {
        int ordernumber = 0;
        int reverseOrderNumber = objList.Count();
        bool didOrderChange = false;
       // Debug.LogWarning("reverse order number is "+ reverseOrderNumber + "\n dynamic " + dynamicOBjList.Count());
        foreach(Transform obj in dynamicShoppingListContent.transform)
        {
          //  Debug.LogWarning(obj.name);

            ObjectiveDataHolder objScript = obj.GetComponent<ObjectiveDataHolder>();

            if (objScript.typeOfItem == GetCurrentAisleItem())
            {
                objScript.isItemHere = true;
                objScript.orderNumber = ordernumber;
                //obj.SetSiblingIndex(ordernumber);
                Debug.Log("something is needed here! " + objScript.typeOfItem + ordernumber);
                ordernumber++;
                didOrderChange = true;

            }
            else
            {
                Debug.LogWarning("script tpe and number" + objScript.typeOfItem + reverseOrderNumber);
                objScript.orderNumber = reverseOrderNumber;
               // obj.SetSiblingIndex(reverseOrderNumber);
                reverseOrderNumber--;
            }
        }

        if (didOrderChange)
        {
            foreach (Transform obj in dynamicShoppingListContent.transform)
            {
                ObjectiveDataHolder objScript = obj.GetComponent<ObjectiveDataHolder>();
                obj.SetSiblingIndex(objScript.orderNumber);
                Debug.LogWarning(objScript.orderNumber + objScript.typeOfItem + "HELP");
            }
        }

    }


    //private int SortFunc(ObjectiveDataHolder a, ObjectiveDataHolder b)
    //{

    //    //  if (a.typeOfItem == null)
    //    if (a.typeOfItem == GetCurrentAisleItem()) { return 1; }
    //    else { return -1; }
    //}

    //private bool SortEquals(ObjectiveDataHolder a)
    //{
    //    if(a.typeOfItem == GetCurrentAisleItem())
    //    {
    //        return true;
    //    }
    //    else return false;
    //}

    public void ShoppingListDisplay()
    {

        foreach (var obj in objectiveData.dynamicObjList)
        {
            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            GameObject dynamicShoppingListItem = Instantiate(textPrefab, dynamicShoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var dynItemName = dynamicShoppingListItem.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();

            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();
            var dynItemQuantity = dynamicShoppingListItem.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();
           
            var itemSprite = shoppingListItems.transform.Find("FoodType_Img").GetComponent<Image>();
            var dynItemSprite = dynamicShoppingListItem.transform.Find("FoodType_Img").GetComponent<Image>();

            ObjectiveDataHolder objDataHolder = dynamicShoppingListItem.GetComponent<ObjectiveDataHolder>();

            itemName.text = obj.itemType;
            dynItemName.text = obj.itemType;
            objDataHolder.typeOfItem = obj.itemType;

            itemQuantity.text = obj.amount.ToString();
            dynItemQuantity.text = obj.amount.ToString();
            objDataHolder.quantity = obj.amount;

            itemSprite.sprite = obj.iconSprite;
            dynItemSprite.sprite = obj.iconSprite;

            objList.Add(new KeyValuePair<string, int>(obj.itemType, obj.amount));
        }
    }

    public void ShowBudget()
    {
        levelBudget_Txt.text = "Budget: $" + objectiveData.budget.ToString("F2");
    }

    public float GetBudget()
    {
        return objectiveData.budget;
    }
}
