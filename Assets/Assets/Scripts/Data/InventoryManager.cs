using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<ItemData> itemList = new List<ItemData>();
    List<int> idList = new List<int>();
    Dictionary<int, int> idDiction = new Dictionary<int, int>();

    public GameObject textPrefab;
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

    public void ShowItem()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        FindIDs();
        Dictionary<int, int> duplicateCounts = CountDuplicates(idList);



        foreach (var item in itemList)
        {

            foreach (KeyValuePair<int, int> pair in duplicateCounts)
            {
                Debug.Log("Element: " + pair.Key + " - Count: " + pair.Value);
                GameObject textObj = Instantiate(textPrefab, itemContent);

                if (pair.Key == item.id)
                {
                    var itemName = textObj.transform.Find("FoodName_Txt").GetComponent<TextMeshProUGUI>();
                    var itemPrice = textObj.transform.Find("FoodPrice_Txt").GetComponent<TextMeshProUGUI>();
                    var itemQuantity = textObj.transform.Find("Quantity_Txt").GetComponent<TextMeshProUGUI>();

                    itemName.text = item.itemName;
                    itemPrice.text = "$" + item.price.ToString();
                }
            }
        }
    }



    Dictionary<int, int> CountDuplicates(List<int> CDlist)
    {
        Dictionary<int, int> duplicateCounts = new Dictionary<int, int>();

        foreach (int element in CDlist)
        {
            if (duplicateCounts.ContainsKey(element))
            {
                duplicateCounts[element]++;
            }
            else
            {
                duplicateCounts[element] = 1;
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
