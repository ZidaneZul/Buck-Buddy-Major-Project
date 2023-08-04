using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawnerTen : MonoBehaviour
{
    public GameObject cash;

  
    
    public Vector3 cashPos;
    public float offset;
    public float offsetCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        //TenDollarSpawner();

    }

    public void TenDollarSpawner()
    {
        // for (int i = 0; i < Random.Range(1, 3); i++)
        // {
        //   int randomCash = Random.Range(0, cash.Length);
        Debug.Log("Adding ten bux");
        var cashSpawn = Instantiate(cash, transform.position, Quaternion.identity);
        cashPos = transform.position;
        offset = offsetCount * 10;
        cashPos.y -= offset;
        cashPos.x -= offset;
        cashSpawn.transform.position = cashPos;
        cashSpawn.transform.SetParent(gameObject.transform, true);

        offsetCount++;
        //}
    }
}
