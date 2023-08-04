using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawner : MonoBehaviour
{
    public GameObject cash;

    public Vector3 cashPos;
    public float offset;
    public int offsetCount = 1;
    
    // Start is called before the first frame update
    void Start()
    {

       // TwoDollarSpawner();
       
    }

    public void TwoDollarSpawner()
    {
        //for (int i = 0; i < Random.Range(1, 7); i++)
        //{
        //Debug.Log("Adding 2 bucks");
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
