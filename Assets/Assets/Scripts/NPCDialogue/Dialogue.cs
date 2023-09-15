using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string NPCname; // NPC's name
    public Sprite NPCimage; // NPC's Model

    [TextArea(3,10)]
    public string[] dialogues;
    public string[] yesResponse;
    public string[] noResponse;
}
