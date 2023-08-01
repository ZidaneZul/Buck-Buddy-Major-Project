using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawnerFive : MonoBehaviour
{
    public GameObject[] cash;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < Random.Range(1, 6); i++)
        {
            int randomCash = Random.Range(0, cash.Length);
            var cashSpawn = Instantiate(cash[randomCash], transform.position, Quaternion.identity);
            cashSpawn.transform.parent = gameObject.transform;
        }

    }
}
