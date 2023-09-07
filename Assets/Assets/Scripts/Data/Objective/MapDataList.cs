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

    //IEnumerable<string> AllAisle()
    //{
    //    foreach (string type in bread) yield type;
    //    foreach (string type in drinks) yield type;
        
    //}
    public string GetAisle(string itemType)
    {
        foreach(string type in bread)
        {
            if (type == itemType)
            {
                return "Bread Aisle";
            }
        }
        foreach (string type in drinks)
        {
            if (type == itemType)
            {
                return "Drinks Aisle";
            }
        }
        foreach (string type in snacks)
        {
            if (type == itemType)
            {
                return "Snacks Aisle";
            }
        }
        foreach (string type in fruits)
        {
            if(type == itemType)
            {
                return "Fruits Vegetable Aisle";
            }
        }
        foreach (string type in frozen)
        {
            if (type == itemType)
            {
                return "Frozen Food Aisle";
            }
        }
        foreach (string type in dairy)
        {
            if (type == itemType)
            {
                return "Dairy Aisle";
            }
        }
        foreach (string type in meat)
        {
            if (type == itemType)
            {
                return "Meat Seafood Aisle";
            }
        }
        foreach (string type in rice)
        {
            if (type == itemType)
            {
                return "Rice Aisle";
            }
        }
        foreach (string type in canned)
        {
            if (type == itemType)
            {
                return "Canned Food Aisle";
            }
        }

        return null;
    }
}
