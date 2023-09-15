using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemData : ScriptableObject
{
    public int id; // Item's ID
    public string itemName; // Item's name
    public float price; // Item's price
    public Sprite icon; // Item's image
    public string itemType; // type of food
}

