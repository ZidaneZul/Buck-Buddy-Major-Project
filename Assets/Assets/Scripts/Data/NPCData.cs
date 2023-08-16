using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPCData/Create New NPC Data")]
public class NPCData : ScriptableObject
{
    

    public class NpcScenario
    {
        public string NPCname;
        public Sprite NPCimage;
        public string dialogue;
        public bool leftImage;
        public bool rightImage;
        public bool PlayerInteraction;
    }

    public NpcScenario[] DynamicNpcScenario;
}


