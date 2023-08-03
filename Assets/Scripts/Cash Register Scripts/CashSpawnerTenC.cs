using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawnerTenC : MonoBehaviour
{
    public GameObject[] cash;

    public Vector3 cashPos;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {

        TenCentSpawner();

    }

    public void TenCentSpawner()
    {
        for (int i = 0; i < Random.Range(1, 20); i++)
        {
            int randomCash = Random.Range(0, cash.Length);
            var cashSpawn = Instantiate(cash[randomCash], transform.position, Quaternion.identity);
            cashPos = transform.position;
            offset = i * 6;
            cashPos.y -= offset;
            cashPos.x -= offset;
            cashSpawn.transform.position = cashPos;
            cashSpawn.transform.SetParent(gameObject.transform, true);
        }
    }
}
