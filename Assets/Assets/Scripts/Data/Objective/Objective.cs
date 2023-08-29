using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public static Objective Instance;
    
    public ObjectiveData objectiveData;

    List<ObjectiveDataHolder> dynamicOBjList = new List<ObjectiveDataHolder>();

    public GameObject textPrefab, shoppingListContent, dynamicShoppingList;
    public List<KeyValuePair<string, int>> objList = new List<KeyValuePair<string, int>>();

    public TextMeshProUGUI levelBudget_Txt;

    public MapLocation mapLocationSript;

    string playerLocation;

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
    }   

    public void GetCurrentAisleItem()
    {
        string location = mapLocationSript.FindPlayer().Replace(" Aisle", "");
        foreach(KeyValuePair<string,int>    obj in objList)
        {
            //if(obj)
        }



    }

    private int SortFunc(ObjectiveDataHolder a)
    {

      //  if (a.typeOfItem == null)
            return 0;
    }

   public void SortShoppingList()
    {
        playerLocation = mapLocationSript.FindPlayer().Split(' ')[0];
    //    objectiveList;
    }

    public void ShoppingListDisplay()
    {
        
        foreach(var obj in objectiveData.dynamicObjList)
        {
            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemSprite = shoppingListItems.transform.Find("FoodType_Img").GetComponent<Image>();

            ObjectiveDataHolder objDataHolder = shoppingListItems.GetComponent<ObjectiveDataHolder>();

            itemName.text = obj.itemType;
            objDataHolder.typeOfItem = obj.itemType;

            itemQuantity.text  = obj.amount.ToString();
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
