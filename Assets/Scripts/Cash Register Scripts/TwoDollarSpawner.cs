using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDollarSpawner : MonoBehaviour
{
    public GameObject moneyToSpawn;
    public Transform[] spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }
    private void SpawnObjects()
    {
        foreach(Transform spawnPosition in spawnPositions)
        {
            Instantiate(moneyToSpawn, spawnPosition.position, spawnPosition.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
