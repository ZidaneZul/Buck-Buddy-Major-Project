using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    //Things added to cart
    public List<ItemData> itemList = new List<ItemData>();

    //used to make the instantiated prefabs have the correct item data attached to them
    public List<ItemData> itemSpawnedList = new List<ItemData>();

    //used to get the quantity for each item in the cart
    public Dictionary<int, int> duplicateCounts;

    //used for finding dups
    List<int> idList = new List<int>();

    //so that the item prefab in cart spawns once per item
    List<int> spawnedCartIds = new List<int>();

    //to attach the data to the item spawned list
    public InventoryItemController[] InventoryItem;

    //List<KeyValuePair<string, int>> cartObjList = new List<KeyValuePair<string, int>>();

    Dictionary<string, int> cartObjDiction = new Dictionary<string, int>();

    Dictionary<string, bool> checkObj = new Dictionary<string, bool>();


    public string[] itemTypeInCart;

    public GameObject textPrefab, cartPanel;
    public Toggle cancelToggle;
    public Transform itemContent;

    public float totalPrice;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       //itemContent = GameObject.Find("Content").transform;
       //cancelToggle = GameObject.Find("ToggleRemove_Btn").GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(itemList.Count);
        Debug.Log("would the player be able to go to cashier ");
    }
    public void Add(ItemData item)
    {
        itemList.Add(item);
    }
    public void Remove(ItemData item)
    {
        Debug.Log("remove item");
        itemList.Remove(item);
    }

    public void ShowItem()
    {
        CleanList();

        FindIDs();

        duplicateCounts = CountDuplicates(idList);

        foreach (var item in itemList)
        {

            foreach (KeyValuePair<int, int> pair in duplicateCounts)
            {
                Debug.Log("Element: " + pair.Key + " - Count: " + pair.Value);
                
                if (pair.Key == item.id && !spawnedCartIds.Contains(item.id))
                {                
                    itemSpawnedList.Add(item);
                    GameObject textObj = Instantiate(textPrefab, itemContent);
                    spawnedCartIds.Add(pair.Key);

                    var itemName = textObj.transform.Find("FoodName_Txt").GetComponent<TextMeshProUGUI>();
                    var itemPrice = textObj.transform.Find("FoodPrice_Txt").GetComponent<TextMeshProUGUI>();
                    var itemQuantity = textObj.transform.Find("Quantity_Txt").GetComponent<TextMeshProUGUI>();
                    itemName.text = item.itemName;
                    itemPrice.text = "$" + item.price.ToString("F2");

                    itemQuantity.text = pair.Value + "x";
                }
            }
        }
        SetInventoryItems();
    }

    Dictionary<int, int> CountDuplicates(List<int> CDlist)
    {
        Dictionary<int, int> duplicateCounts = new Dictionary<int, int>();

        foreach (int idNumber in CDlist)
        {
            if (duplicateCounts.ContainsKey(idNumber))
            {
                duplicateCounts[idNumber]++;
                //Debug.Log("Duplicate count " + duplicateCounts[idNumber]
                //    + "\n element is " + idNumber );
            }
            else
            {
                duplicateCounts[idNumber] = 1;
            }
        }

        return duplicateCounts;
    }

    public void CleanList()
    {
        //Debug.Log("cleaning clean clean");
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        idList.Clear();
        spawnedCartIds.Clear();
        itemSpawnedList.Clear();
        
    }
    void FindIDs()
    {
        if (cartPanel.activeInHierarchy)
        {
            //Debug.Log("Cart is open");
            foreach(var item in itemList)
            {
                idList.Add(item.id);
            }
        }
        else
        {
           // Debug.Log("Cart is close");
            cancelToggle.isOn = false;
        }
    }
    
    public void EnableItemsRemove()
    {
        if (cancelToggle.isOn)
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Cancel_Btn").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Cancel_Btn").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        //Debug.Log("Setting inv items");
        InventoryItem = itemContent.GetComponentsInChildren<InventoryItemController>();
        
        for (int i = 0; i < spawnedCartIds.Count; i++)
        {
            InventoryItem[i].AddItem(itemSpawnedList[i]);
            InventoryItem[i].getItemQuantity = false;
            
        }
    }

    public void GetTotalValue()
    {
        foreach (var item in itemList)
        {
            totalPrice += item.price;            
        }
    }

    public void GoToCashier()
    {
        if (CheckForObj())
        {
            Debug.Log("Go to cashier nownwownwonw");
        }
        else
            Debug.Log("Mising items pls find");
    }

    public bool CheckForObj()
    {
        //cartObjDiction is getting the types of food players have added to cart.
        cartObjDiction.Clear();

        //checkObj is a dictionary thats a string and bool to check if the player have sufficient 
        //items from the shopping list.
        checkObj.Clear();

        foreach (var item in itemList)
        {
            Debug.Log("ITEM");

            //s Debug.Log(objItem.Key + item.itemType + string.Equals(objItem.Key, item.itemType));
            if (cartObjDiction.ContainsKey(item.itemType))
            {
                Debug.Log("There is a dupe");
                cartObjDiction[item.itemType]++;
            }
            else
            {
                cartObjDiction[item.itemType] = 1;
                Debug.Log("there is a new food type");
            }
            Debug.Log(item.itemType + cartObjDiction[item.itemType].ToString());
        }

        foreach (KeyValuePair<string, int> obj in Objective.Instance.objList)
        {
            checkObj.Add(obj.Key, false);

            foreach (KeyValuePair<string, int> cart in cartObjDiction)
            {
                Debug.Log("Cart Key is " + cart.Key + "\n OBJ key is " + obj.Key);
                if (cart.Key.Equals(obj.Key))
                {
                    if (cart.Value >= obj.Value)
                    {
                        checkObj[obj.Key] = true;
                        break;
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
        foreach(KeyValuePair<string, bool> checks in checkObj)
        {
            if (!checks.Value)
            {
                Debug.Log("Missing items!");
                Debug.Log("doin the function to find whats missing");
                return false;
            }
        }
        Debug.Log("Proceed to cashier");
        return true;
    }

    void FindMissingItems()
    {

    }
}
