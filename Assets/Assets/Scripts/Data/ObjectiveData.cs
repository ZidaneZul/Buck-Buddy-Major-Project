using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective", menuName = "ObjectiveData/Create New Objective")]
public class ObjectiveData : ScriptableObject
{
    public int Soup;
    public int Lettuce;
    public int Cheese;
    public int Tomatoes;
    public int Noodles;
    public int Eggs;
    public int Bread;
    public int Mushrooms;
    public int Meat;
    public int SoySauce;
    public int Ham;
    public string[] ListOfFoodTypes = { "Soup", "Lettuce", "Cheese", "Tomatoes", "Noodles", "Eggs", "Bread", "Mushrooms", "Meat", "SoySauce", "Ham" };
    public int[] Quantity = new int[11];





}