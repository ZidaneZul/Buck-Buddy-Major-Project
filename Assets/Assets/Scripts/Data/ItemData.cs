using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public float price;
    public Sprite icon;
}

