using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawning : MonoBehaviour
{
    public GameObject Player,NPC,spawnedNpc;
    public GameObject[] TypesOfNpc;
    public List<GameObject> NPCspawnerLocations;
    public int numberHolder;
    public DialogueManager dialogueManager;


    // Start is called before the first frame update
    void Start()
    {
        NPCspawnerLocations = new List<GameObject>(GameObject.FindGameObjectsWithTag("Waypoint"));
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
        FindClosestWaypoint();
    }

    // Update is called once per frame
    void Update()
    {

        if(dialogueManager.NPCInteracted == false)
        {
            if (PlayerInVicinity())
            {
                dialogueManager.StartDialogue();
                dialogueManager.NPCInteracted = true;
            }
        }


    }

    void FindClosestWaypoint()
    {
        float distanceToClosestWaypoint = Mathf.Infinity;
        GameObject closestWaypoint = null;
        foreach(GameObject waypoint in NPCspawnerLocations)
        {
            float distanceToPlayer = (waypoint.transform.position - Player.transform.position).sqrMagnitude;
            if(distanceToPlayer < distanceToClosestWaypoint)
            {
                distanceToClosestWaypoint = distanceToPlayer;
                closestWaypoint = waypoint;
                NPCspawnerLocations.Remove(closestWaypoint);
                SpawnNPC();


            }


        }
    }

    void SpawnNPC()
    {
        if(dialogueManager.npcData.name == "Scammer")
        {
            NPC = TypesOfNpc[1];
        }
        if (dialogueManager.npcData.name == "GoodHelper")
        {
            NPC = TypesOfNpc[0];
        }
        numberHolder = Random.Range(0, NPCspawnerLocations.Count);
        spawnedNpc = Instantiate(NPC, NPCspawnerLocations[numberHolder].transform);
    }

    bool PlayerInVicinity()
    {
        if(Vector3.Distance(Player.transform.position, spawnedNpc.transform.position) <= 5f)
        {
            return true;

        }
        else
        {
            return false;
        }
    }
}

