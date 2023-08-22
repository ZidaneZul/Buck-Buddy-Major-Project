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

    public GameObject textPrefab, cartPanel,cartAmount;
    public TextMeshProUGUI cartQuantity;
    public Toggle cancelToggle;
    public Transform itemContent;
    public int itemsInCart;

    string missingItems;
    public float totalPrice;
    public float budget;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cartAmount.SetActive(false);
        //itemContent = GameObject.Find("Content").transform;
        //cancelToggle = GameObject.Find("ToggleRemove_Btn").GetComponent<Toggle>();
        // itemList = PaymentDrop.storedData;
        foreach (ItemData item in PaymentDrop.storedData)
        {
            itemList.Add(item);
            totalPrice += item.price;
        }
        budget = Objective.Instance.GetBudget();
    }

    // Update is called once per frame
    void Update()
    {
        if(itemsInCart > 0)
        {
            cartAmount.SetActive(true);
            cartQuantity.text = itemsInCart.ToString();
            if(itemsInCart >= 9)
            {
                cartQuantity.text = "9+";
            }
        }
        Debug.Log("Total price is " + totalPrice);

        BudgetRemainder();
    }
    public void Add(ItemData item)
    {
        itemList.Add(item);
        totalPrice += item.price;
        itemsInCart++;
        budget -= item.price;
    }
    public void Remove(ItemData item)
    {
        Debug.Log("remove item");
        itemList.Remove(item);
        totalPrice -= item.price;
        itemsInCart--;
        budget += item.price;
    }

    public void BudgetRemainder()
    {
        if ((budget - totalPrice) <= 5f)
        {
            Debug.Log("Getting close to budget!");
        }
    }

    public void ShowItem()
    {
        //cleans all used list before doing code
        CleanList();
        FindIDs();

        //Finds the amount of dups an item have
        //3 ntuc bread, 1 egg, 9 ham etc.
        duplicateCounts = CountDuplicates(idList);


        //goes through items list
        foreach (var item in itemList)
        {
            //goes through the pairs in the dup count list
            foreach (KeyValuePair<int, int> pair in duplicateCounts)
            {
                Debug.Log("Element: " + pair.Key + " - Count: " + pair.Value);
                
                //if the id number in the dup count matches the id in the item list AND
                //it was the first unique item id to be added, makes a cart slot and adds the
                //name price and quantity of the item.
                //Adds to itemSpawnedList so that the cart slot would contain the correct item script.
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
            foreach (var item in itemList)
            {
                idList.Add(item.id);
            }
        }
        //else
        //{
        //    // Debug.Log("Cart is close");
        //    cancelToggle.isOn = false;
        //}
    }

    //public void EnableItemsRemove()
    //{
    //    if (cancelToggle.isOn)
    //    {
    //        foreach (Transform item in itemContent)
    //        {
    //            item.Find("Cancel_Btn").gameObject.SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        foreach (Transform item in itemContent)
    //        {
    //            item.Find("Cancel_Btn").gameObject.SetActive(false);
    //        }
    //    }
    //}

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


        //this code would get the total amount of food items. 5 bread (of any brand) etc.
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
           // Debug.Log(item.itemType + cartObjDiction[item.itemType].ToString());
        }

        //this would check if the player have enuf item type based on the level obj.
        foreach (KeyValuePair<string, int> obj in Objective.Instance.objList)
        {
            //adds the item type with a false bool pair to the dictionary.
            checkObj.Add(obj.Key, false);

            //goes thru the list of the amount of item types in the player's cart
            foreach (KeyValuePair<string, int> cart in cartObjDiction)
            {

                Debug.Log("Cart Key is " + cart.Key + "\n OBJ key is " + obj.Key);
                if (cart.Key.Equals(obj.Key))
                {
                    //makes the bool true if the player has enuf item type for the level obj
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

        //goes thru the final dictionary to check if the player does have enuf item types
        // depend on the true or false statement from the dictionary
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

    public string FindMissingItems()
    {
        missingItems = "";
        bool firstItemAdded = false;
        foreach (KeyValuePair<string, bool> checks in checkObj)
        {
            if (!checks.Value)
            {
                Debug.Log(checks.Key);
                foreach (KeyValuePair<string, int> obj in Objective.Instance.objList)
                {
                    if (obj.Key.Equals(checks.Key))
                    {

                        if (!firstItemAdded)
                        {
                            missingItems += " " + obj.Value + " " + obj.Key;
                            firstItemAdded = true;
                        }
                        else
                        {
                            missingItems += ", " + obj.Value + " " + obj.Key;
                        }
                    }
                }
            }
        }
        return "You need" + missingItems + "!";
    }
    public string NPCFindMissingItem()
    {

        CheckForObj();

        bool breakLoops = false;
        Debug.Log("NPC Finding missing items" + breakLoops);
        missingItems = "";
        foreach (KeyValuePair<string, bool> checks in checkObj)
        {
            Debug.Log(checks.Key + checks.Value);
            if (!checks.Value)
            {

                Debug.Log(checks.Key);
                foreach (KeyValuePair<string, int> obj in Objective.Instance.objList)
                {
                    if (obj.Key.Equals(checks.Key))
                    {
                        Debug.Log("Found missing item" + obj.Key);
                       missingItems += obj.Key;

                        breakLoops = true;
                        break;
                    }
                }
                if (breakLoops)
                {
                    break;
                }
            }
            if (breakLoops)
            {
                break;
            }
        }
        return missingItems;
    }
}
