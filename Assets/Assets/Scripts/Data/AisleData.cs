using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Aisle Data", menuName = "AisleData/Create new Aisle Data")]

public class AisleData : ScriptableObject
{
    [System.Serializable]
    public class AisleDataHolder
    {
        public GameObject Aisle; // Hold the Aisle waypoint
        public string[] FoodTypeInAisle; // the different food types that are in the Aisle
    }

    public AisleDataHolder[] aisleDataHolder;
}
