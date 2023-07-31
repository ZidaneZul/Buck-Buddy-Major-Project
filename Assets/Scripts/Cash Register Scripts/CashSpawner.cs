using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawner : MonoBehaviour
{
    public GameObject[] cash;
    public Vector3 yPosition = -2 * Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < 10; i++)
        {
            int randomCash = Random.Range(0, cash.Length);
            var cashSpawn = Instantiate(cash[randomCash], transform.position, Quaternion.identity);
            cashSpawn.transform.parent = gameObject.transform;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
