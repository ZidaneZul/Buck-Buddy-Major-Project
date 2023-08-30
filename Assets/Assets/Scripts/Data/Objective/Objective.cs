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
        foreach (KeyValuePair<string, int> obj in objList)
        {
            Debug.Log("Require food type is " + obj.Key + " " + obj.Value);
        }
        levelBudget_Txt = GameObject.Find("LevelBudget_Txt").GetComponent<TextMeshProUGUI>();

        ShowBudget();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentAisleItem();
    }

    public string GetCurrentAisleItem()
    {
        string location = mapLocationSript.FindPlayer().Split(' ')[0];
        Debug.Log(location);
        string[] aisleItemType = MapDataList.instance.GetAisleTypes(location);
        Debug.Log(objList.Count);
        foreach (KeyValuePair<string, int> obj in objList)
        {
            Debug.Log("help me");
            foreach (var aisleType in aisleItemType)
            {
                Debug.Log(obj.Key + "\n" + aisleType);
                if (obj.Key == aisleType)
                {
                    Debug.LogWarning("Something is needed here");
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
        //   playerLocation = mapLocationSript.FindPlayer().Split(' ')[0];
        //    objectiveList;
    //    dynamicOBjList.Sort(SortFunc(GetCurrentAisleItem()));
    }


    private int SortFunc(ObjectiveDataHolder a)
    {

        //  if (a.typeOfItem == null)
        if (a.typeOfItem == GetCurrentAisleItem()) { return 1; }
        else { return -1; }
    }

    public void ShoppingListDisplay()
    {

        foreach (var obj in objectiveData.dynamicObjList)
        {
            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemSprite = shoppingListItems.transform.Find("FoodType_Img").GetComponent<Image>();

            ObjectiveDataHolder objDataHolder = shoppingListItems.GetComponent<ObjectiveDataHolder>();

            itemName.text = obj.itemType;
            objDataHolder.typeOfItem = obj.itemType;

            itemQuantity.text = obj.amount.ToString();
            objDataHolder.quantity = obj.amount;

            itemSprite.sprite = obj.iconSprite;

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