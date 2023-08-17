using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPCData/Create New NPC Data")]
public class NPCData : ScriptableObject
{
    [System.Serializable]

    public class NpcScenario
    {
        public string dialogue;
        public bool FirstImage;
        public bool SecondImage;
        public bool PlayerInteraction;
        
    }
    public enum MyEnum // your custom enumeration
    {
        Scammer,
        Helper
       
    };
    [SerializeField]
    public MyEnum ScenarioType = new MyEnum();
    public string FirstPersonName, SecondPersonName;
    public Sprite FirstPerson, SecondPerson;
    public string[] yes, no;
    public NpcScenario[] DynamicNpcScenario;
    

    
}


