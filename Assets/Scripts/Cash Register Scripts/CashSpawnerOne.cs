using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawnerOne : MonoBehaviour
{
    public GameObject[] cash;

    public Vector3 cashPos;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {

        OneDollarSpawner();
    }   

    public void OneDollarSpawner()
    {
        for (int i = 0; i < Random.Range(1, 10); i++)
        {
            int randomCash = Random.Range(0, cash.Length);
            var cashSpawn = Instantiate(cash[randomCash], transform.position, Quaternion.identity);
            cashPos = transform.position;
            offset = i * 5;
            cashPos.y -= offset;
            cashPos.x -= offset;
            cashSpawn.transform.position = cashPos;
            cashSpawn.transform.SetParent(gameObject.transform, true);
        }
    }
}
