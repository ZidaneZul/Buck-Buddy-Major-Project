using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;
    public List<ItemData> Items = new List<ItemData>();

    TextMeshProUGUI TMP;

    string listOfCart;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        TMP = GameObject.Find("CartBody_Txt").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Items.Count);
    }
    public void Add(ItemData item)
    {
        Items.Add(item);
    }

    public void ShowItem()
    {
        listOfCart = null;
        Debug.Log("Triggered");
        foreach (var item in Items)
        {
            listOfCart += item.itemName + "\n";
            //listOfCart.
        }   
        TMP.text = listOfCart;
    }
}
