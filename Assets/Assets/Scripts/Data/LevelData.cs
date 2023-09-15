using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "LevelData/Create New Level Data")]


public class LevelData : ScriptableObject
{
    [System.Serializable]
    public class LevelDataHolder
    {
        public int levelNumber; // Level Number 
        public int levelStarAmount; // The player's highscore
        public string foodName; // The objective's food name
        public Sprite itemToMake; // The image of the food
        public string[] ingredients; // The objective ingredients the player would need to find
    }
    [SerializeField]
    public LevelDataHolder[] levelDataHolder;
}
