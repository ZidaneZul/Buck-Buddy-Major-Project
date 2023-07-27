using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDollarSpawner : MonoBehaviour
{
    public GameObject money2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < 10; i++)
        {
            Instantiate(money2, transform.position, Quaternion.identity);
        }
    }
}
