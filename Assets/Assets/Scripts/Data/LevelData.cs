using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "LevelData/Create New Level Data")]


public class LevelData : ScriptableObject
{
    [System.Serializable]
    public class LevelDataHolder
    {
        public int levelNumber;
        public int levelStarAmount;
        public string foodName;
        public Sprite itemToMake;
        public string[] ingredients;
    }
    [SerializeField]
    public LevelDataHolder[] levelDataHolder;
}
