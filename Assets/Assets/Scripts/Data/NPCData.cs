using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPCData/Create New NPC Data")]
public class NPCData : ScriptableObject
{
    public string[] NPCname;
    public Sprite[] NPCimage;

    [TextArea(3, 10)]
    public string[] dialogues;
    public string yesResponse;
    public string noResponse;
    public string[] NPCResponses;
    public int LineToStopAt;
}
