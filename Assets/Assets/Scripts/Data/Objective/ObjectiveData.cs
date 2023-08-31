using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective", menuName = "ObjectiveData/Create New Objective")]
public class ObjectiveData : ScriptableObject
{
    [System.Serializable]
    public class ItemObjListThing
    {
        public string itemType;
        public int amount;
        public Sprite iconSprite;
    }
    public ItemObjListThing[] dynamicObjList;
    public float budget;
}