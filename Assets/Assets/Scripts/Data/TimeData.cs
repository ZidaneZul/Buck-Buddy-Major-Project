using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Time Data", menuName = "TimeData/Create New Time Data")]
public class TimeData : ScriptableObject
{
    public float mainLevelTime;  // To hold time taken in main level
    public float cashierTime; // To hold time taken in cashier scene
}
