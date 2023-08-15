using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawning : MonoBehaviour
{
    public GameObject Player,NPC,spawnedNpc;
    public List<GameObject> NPCspawnerLocations;
    public int numberHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        NPCspawnerLocations = new List<GameObject>(GameObject.FindGameObjectsWithTag("Waypoint"));

        Player = GameObject.FindGameObjectWithTag("Player");
        
        FindClosestWaypoint();
    }

    // Update is called once per frame
    void Update()
    {

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
        numberHolder = Random.Range(0, NPCspawnerLocations.Count);
        spawnedNpc = Instantiate(NPC, NPCspawnerLocations[numberHolder].transform);
    }
}
