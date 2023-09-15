using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPCData/Create New NPC Data")]
public class NPCData : ScriptableObject
{
    [System.Serializable]

    public class NpcScenario
    {
        public string dialogue; // The dialogue that would be displayed
        public bool FirstImage; // Whether the person on the left is talking
        public bool SecondImage; // Whether the person on the right is talking
        public bool PlayerInteraction; // Whether the player would need to awnser yes or no
        
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


