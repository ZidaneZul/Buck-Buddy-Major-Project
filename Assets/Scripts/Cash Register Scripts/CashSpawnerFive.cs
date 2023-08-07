using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawnerFive : MonoBehaviour
{
    public GameObject cash;

    public Vector3 cashPos;
    public float offset;
    public float offsetCount = 1;

    // Start is called before the first frame update
    void Start()
    {
       // FiveDollarSpawner();
    }

    public void FiveDollarSpawner()
    {
        // for (int i = 0; i < Random.Range(1, 6); i++)
        // {
        Debug.Log("Adding 5 bux");
        var cashSpawn = Instantiate(cash, transform.position, Quaternion.identity);
        cashPos = transform.position;
        offset = offsetCount * 5;
        cashPos.y -= offset;
        cashPos.x -= offset;
        cashSpawn.transform.position = cashPos;
        cashSpawn.transform.SetParent(gameObject.transform, true);
        cashSpawn.transform.localScale = new Vector3(1, 1, 1);

        offsetCount++;
        // }
    }
}
