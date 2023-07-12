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
        ShowItem();
    }
    public void Add(ItemData item)
    {
        Items.Add(item);
    }

    public void ShowItem()
    {
        TMP.text = "IMGAHY";
        foreach (var item in Items)
        {
            Debug.Log("The item is " + item);

        }   
    }
}
