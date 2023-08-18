using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public static Objective Instance;
    
    public ObjectiveData objectiveData;

    public GameObject textPrefab, shoppingListContent;
    public List<KeyValuePair<string, int>> objList = new List<KeyValuePair<string, int>>();

    public TextMeshProUGUI levelBudget_Txt;

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

   
    public void ShoppingListDisplay()
    {
        
        foreach(var obj in objectiveData.dynamicObjList)
        {
            GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
            var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();
            var itemSprite = shoppingListItems.transform.Find("FoodType_Img").GetComponent<Image>();

            itemName.text = obj.itemType;
            itemQuantity.text  = obj.amount.ToString();
            itemSprite.sprite = obj.iconSprite;

            objList.Add(new KeyValuePair<string, int>(obj.itemType, obj.amount));

        }
        //if(objectiveData.Soup > 0)
        //{
        //    Debug.Log("Soup Needed: " + objectiveData.Soup);

        //    GameObject shoppingListItems = Instantiate(textPrefab, shoppingListContent.transform);
        //    var itemName = shoppingListItems.transform.Find("FoodNameCart_Txt").GetComponent<TextMeshProUGUI>();
        //    var itemQuantity = shoppingListItems.transform.Find("QuantityCart_Txt").GetComponent<TextMeshProUGUI>();

        //    itemName.text = "Soup ";
        //    itemQuantity.text = objectiveData.Soup + "x";

        //    objList.Add(new KeyValuePair<string, int>("Soup", objectiveData.Soup));
        //}

        
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
