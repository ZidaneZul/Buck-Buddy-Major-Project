using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Category", menuName = "Sign/Create New Sign Data")]
public class SignBoardData : ScriptableObject
{
    public string itemName1; // Row 1 of the hanging signboard, Name of item 1
    public string itemName2; // Row 2 of the hanging signboard, Name of item 2
    public string itemName3; // Row 3 of the hanging signboard, Name of item 3
    public Sprite Icon; // Food aisle image
}

