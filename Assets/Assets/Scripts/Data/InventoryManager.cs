using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<ItemData> itemList = new List<ItemData>();

    //used to make the instantiated prefabs have the correct item data attached to them
    public List<ItemData> itemSpawnedList = new List<ItemData>();

    public Dictionary<int, int> duplicateCounts;

    //used for finding dups
    List<int> idList = new List<int>();

    //so that the item prefab in cart spawns once per item
    List<int> spawnedCartIds = new List<int>();
    public InventoryItemController[] InventoryItem;

    public GameObject textPrefab;
    Toggle cancelToggle;
    Transform itemContent;

    bool isCartOpen =false;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        itemContent = GameObject.Find("Content").transform;
        cancelToggle = GameObject.Find("ToggleRemove_Btn").GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(itemList.Count);
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
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

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
                    itemPrice.text = "$" + item.price.ToString();

                    itemQuantity.text = pair.Value + "x";
                }
            }
        }
        SetInventoryItems();
    }

    public void RecountCartItems()
    {
        duplicateCounts = CountDuplicates(idList);
    }



    Dictionary<int, int> CountDuplicates(List<int> CDlist)
    {
        Dictionary<int, int> duplicateCounts = new Dictionary<int, int>();

        foreach (int idNumber in CDlist)
        {
            if (duplicateCounts.ContainsKey(idNumber))
            {
                duplicateCounts[idNumber]++;
                Debug.Log("Duplicate count " + duplicateCounts[idNumber]
                    + "\n element is " + idNumber );
            }
            else
            {
                duplicateCounts[idNumber] = 1;
            }
        }

        return duplicateCounts;
    }

    void FindIDs()
    {
        if (!isCartOpen)
        {
            isCartOpen = true;
            foreach(var item in itemList)
            {
                idList.Add(item.id);
            }
        }
        else
        {
            isCartOpen = false;
            idList.Clear();
            spawnedCartIds.Clear();
            itemSpawnedList.Clear();
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
        InventoryItem = itemContent.GetComponentsInChildren<InventoryItemController>();
        
        for (int i = 0; i < spawnedCartIds.Count; i++)
        {
            InventoryItem[i].AddItem(itemSpawnedList[i]);
            InventoryItem[i].getItemQuantity = false;
            
        }
    }

    //void FindDuplicates()
    //{
    //    if (!isCartOpen)
    //    {
    //        isCartOpen = true;
    //        Debug.Log("Cart is now open");

    //        foreach (var item in itemList)
    //        {
    //            testList.Add(item.id);
    //            if (uniqueIdList.Contains(item.id))
    //            {
    //               // Debug.Log("Duplicate found!");
    //                duplicatedList.Add(item.id);
    //               // Debug.Log("item " + item.id + "has be found ");
    //            }
    //            else
    //            {
    //                //Debug.Log("not a dup!");
    //                uniqueIdList.Add(item.id);
    //            }
    //            //Debug.Log("Unique id: " + uniqueIdList.ToString());
    //        }
    //    }
    //    else
    //    {
    //        isCartOpen = false;
    //        uniqueIdList.Clear();
    //        testList.Clear();
    //        Debug.Log("cart is now close");
    //    }
    //}
}
