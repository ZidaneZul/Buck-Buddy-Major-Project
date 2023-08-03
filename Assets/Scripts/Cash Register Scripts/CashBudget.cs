using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CashBudget : MonoBehaviour
{
    public float cashBudget;
    public float coinsBudget = 2f;
    public float cashCfm = 17f;
    float remainBudget;
    float value;

    CashSpawnerOne oneDollarScript;
    CashSpawner twoDollarScript;
    CashSpawnerFive fiveDollarScript;
    CashSpawnerTen tenDollarScript;


    public GameObject[] spawners;
    // Start is called before the first frame update
    void Start()
    {     
        cashBudget = Random.Range(30f, 50f);
        remainBudget = cashBudget - coinsBudget - cashCfm;
        Debug.Log("Cash: " + cashBudget.ToString("F2"));
        
        spawners[0] = GameObject.Find("2DollarSpawner");
        twoDollarScript = spawners[0].GetComponent<CashSpawner>();
       
        spawners[1] = GameObject.Find("5DollarSpawner");
        fiveDollarScript = spawners[1].GetComponent<CashSpawnerFive>();

        spawners[2] = GameObject.Find("10DollarSpawner");
        tenDollarScript = spawners[2].GetComponent<CashSpawnerTen>();   

        spawners[3] = GameObject.Find("1DollarSpawner");
        oneDollarScript = spawners[3].GetComponent<CashSpawnerOne>();

    }


    public void BudgetManager()
    {
        for (float i = remainBudget; i == 0; i -= value)
        {
           int random = Random.Range(1, spawners.Length);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
