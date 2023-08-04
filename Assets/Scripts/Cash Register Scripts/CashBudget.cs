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

    string textToRemove = "DollarSpawner";

    float twoDollarValue, fiveDollarValue, tenDollarValue;

    public GameObject[] spawners;
    public GameObject oneDollarSpawner;
    // Start is called before the first frame update
    void Start()
    {     
        cashBudget = Random.Range(30f, 50f);
        remainBudget = cashBudget - coinsBudget - cashCfm;
        Debug.Log("Cash: " + cashBudget.ToString("F2"));
        
        spawners[0].name.Remove(1);
        twoDollarScript = spawners[0].GetComponent<CashSpawner>();
        

        spawners[1].name.Remove(1);
        fiveDollarScript = spawners[1].GetComponent<CashSpawnerFive>();

        spawners[2].name.Remove(1);
        tenDollarScript = spawners[2].GetComponent<CashSpawnerTen>();   

        oneDollarSpawner = GameObject.Find("1DollarSpawner");
        oneDollarScript = oneDollarSpawner.GetComponent<CashSpawnerOne>();

        foreach(GameObject spawner in spawners)
        {
            Debug.Log(spawner.name.Remove(1));
        }
    }


    public void BudgetManager()
    {
        for (float i = remainBudget; i == 0; i -= value)
        {
           int random = Random.Range(1, spawners.Length);
            Debug.Log(remainBudget);
            if (float.Parse(spawners[random].name.Replace(textToRemove, "")) < remainBudget)
            {
                remainBudget -= float.Parse(spawners[random].name.Replace(textToRemove, ""));
                if (random == 0)
                    twoDollarScript.TwoDollarSpawner();
                else if (random == 1)
                    fiveDollarScript.FiveDollarSpawner();
                else if (random == 2)
                    tenDollarScript.TenDollarSpawner();
            }
            else if(float.Parse(spawners[random].name.Replace(textToRemove, "")) == 1)
            {
                remainBudget -= 1;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
