using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string NPCname;
    public Image NPCimage;

    [TextArea(3,10)]
    public string[] dialogues;
}
