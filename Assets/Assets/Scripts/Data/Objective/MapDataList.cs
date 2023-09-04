using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataList : MonoBehaviour
{
    public static MapDataList instance;

    private void Awake()
    {
        instance = this;
    }
    public string[] GetAisleTypes(string aisle)
    {
        switch (aisle)
        {
            case "Bakery":
                string[] str = new string[1];
                str[0] = "Bread";
                return str;
            case "Drinks":
                string[] drinks = new string[1];
                drinks[0] = "Drink";
                return drinks;
            case "Snacks":
                string[] snacks = { "Chips", "Cookies" };
                return snacks;
            case "Fruits":
                string[] fruits = { "Onions", "Broccoli", "Lemon", "Orange", "Lettuce",
                "Mushrooms", "Tomatoes", "Mint", "Pineapple", "Cucumber", "Ginger", "Spinach"};
                return fruits;
            case "Frozen":
                string[] frozen = { "PizzaDough", "Frozen" };
                return frozen;
            case "Dairy":
                string[] dairy = { "Egg" };
                return dairy;   
          //  case "Canned":
            case "Meat":
                string[] meat = { "Ham", "Chicken" };
                return meat;
            default:
                return null;
          //  case "Rice":
        }
    }
}
