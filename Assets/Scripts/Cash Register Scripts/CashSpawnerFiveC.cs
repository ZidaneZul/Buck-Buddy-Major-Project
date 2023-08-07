using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawnerFiveC : MonoBehaviour
{
    public GameObject cash;
    public Vector3 cashPos;
    public float offset;
    public float offsetCount = 1;

    // Start is called before the first frame update
    void Start()
    {

        //FiveCentSpawner();
    }

    public void FiveCentSpawner()
    {
        var cashSpawn = Instantiate(cash, transform.position, Quaternion.identity);
        cashPos = transform.position;
        offset = offsetCount * 10;
        cashPos.y -= offset;
        cashPos.x -= offset;
        cashSpawn.transform.position = cashPos;
        cashSpawn.transform.SetParent(gameObject.transform, true);

        offsetCount++;

    }
}
