using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<ItemData> itemList = new List<ItemData>();
    public InventoryItemController[] InventoryItem;

    //used to make the instantiated prefabs have the correct item data attached to them
    //public List<ItemData> itemSpawnedList = new List<ItemData>();

    //public Dictionary<int, int> duplicateCounts;

    //used for finding dups
    //List<int> idList = new List<int>();

    //so that the item prefab in cart spawns once per item
    //List<int> spawnedCartIds = new List<int>();


    //gameobjects and other variables
    public GameObject textPrefab, shoppingCartPanel;
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
        shoppingCartPanel = GameObject.Find("Cart_Panel");
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
        FindIDs();
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in itemList)
        {

            GameObject textObj = Instantiate(textPrefab, itemContent);
           
            var itemName = textObj.transform.Find("FoodName_Txt").GetComponent<TextMeshProUGUI>();
            var itemPrice = textObj.transform.Find("FoodPrice_Txt").GetComponent<TextMeshProUGUI>();
            //var itemQuantity = textObj.transform.Find("Quantity_Txt").GetComponent<TextMeshProUGUI>();
            itemName.text = item.itemName;
            itemPrice.text = "$" + item.price.ToString();
        }
        SetInventoryItems();
    }


    void FindIDs()
    {
        if (shoppingCartPanel.activeInHierarchy)
        {
          
        }
        else
        {
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

        for(int i = 0; i < itemList.Count; i++)
        {
            InventoryItem[i].AddItem(itemList[i]);
        }
    }
}
