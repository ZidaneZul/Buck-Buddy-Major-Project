using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Time Data", menuName = "TimeData/Create New Time Data")]
public class TimeData : ScriptableObject
{
    public float mainLevelTime;
    public float cashierTime;
}
