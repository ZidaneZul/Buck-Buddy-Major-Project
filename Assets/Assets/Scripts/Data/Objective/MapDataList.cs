using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataList : MonoBehaviour
{

    string[] bread = { "Bread" };
    string[] drinks = { "Drink" };
    string[] snacks = { "Chips", "Cookies" };
    string[] fruits = { "Onions", "Broccoli", "Lemon", "Orange", "Lettuce",
                "Mushrooms", "Tomatoes", "Mint", "Pineapple", "Cucumber", "Ginger", "Spinach"};
    string[] frozen = { "PizzaDough", "Frozen" };
    string[] dairy = { "Egg", "Cheese" };
    string[] meat = { "Ham", "Chicken" };
    string[] rice = { "Noodles", "Flour", "SoySauce", "Soup", "Rice" };
    string[] canned = { "TomtatoPaste" };


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
                return bread;
            case "Drinks":
                return drinks;
            case "Snacks":
                return snacks;
            case "Fruits":
                return fruits;
            case "Frozen":
                return frozen;
            case "Dairy":
                return dairy;
            case "Meat":
                return meat;
            case "Rice":
                return rice;
            case "Canned":
                return canned;
            default:
                return null;
        }
    }

    IEnumerable<string> AllAisle()
    {
        foreach (string type in bread) yield type;
        foreach (string type in drinks) yield type;
        
    }
    public string GetAisle(string itemType)
    {
        foreach(string type in bread)
        {
            if (type == itemType)
            {
                return "Bread Aisle";
            }
        }
        return null;
    }
}
