using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CashBudget : MonoBehaviour
{
    public float cashBudget;
    public float coinsBudget = 2f;
    public float coinsBudgetInCents = 200f;
    public float cashCfm = 17f;
    float remainBudget;
    float value;

    CashSpawner twoDollarScript;
    CashSpawnerFive fiveDollarScript;
    CashSpawnerTen tenDollarScript;

    CashSpawnerFiveC fiveCentScript;
    CashSpawnerTenC tenCentScript;
    CashSpawnerTwentyC twentyCentScript;
    CashSpawnerFiftyC fiftyCentScript;
    CashSpawnerOne oneDollarScript;


    string textToRemoveNote = "DollarSpawner";
    string textToRemoveCoin = "cSpawner";


    public GameObject[] noteSpawners;
    public GameObject[] coinSpawners;
    public GameObject oneDollarSpawner;
    // Start is called before the first frame update
    void Start()
    {     
        cashBudget = Random.Range(30f, 50f);
        cashBudget = Mathf.Round((cashBudget * 100.0f) * 0.01f);
        remainBudget = cashBudget - coinsBudget - cashCfm;
        Debug.Log("Cash: " + cashBudget.ToString("F2"));
        
        twoDollarScript = noteSpawners[0].GetComponent<CashSpawner>();
        fiveDollarScript = noteSpawners[1].GetComponent<CashSpawnerFive>();

        tenDollarScript = noteSpawners[2].GetComponent<CashSpawnerTen>();   

        oneDollarSpawner = GameObject.Find("1DollarSpawner");
        oneDollarScript = oneDollarSpawner.GetComponent<CashSpawnerOne>();

        fiveCentScript = coinSpawners[0].GetComponent<CashSpawnerFiveC>();
        tenCentScript = coinSpawners[1].GetComponent<CashSpawnerTenC>();
        twentyCentScript = coinSpawners[2].GetComponent<CashSpawnerTwentyC>();
        fiftyCentScript = coinSpawners[3].GetComponent<CashSpawnerFiftyC>();

        //BudgetManager();

        //foreach(GameObject spawner in spawners)
        //{
        //    Debug.Log(spawner.name.Remove(1));
        //}
    }
    void Update()
    {
        NotesRandomise();
        CoinsRandomise();
    }


    public void NotesRandomise()
    {

        if(remainBudget > 0)
        //for (float i = remainBudget; i == 0; i -= value)
        {
         //   Debug.Log("remaining budget" + remainBudget);
            int random = Random.Range(0, noteSpawners.Length);
            float randomNoteValue = float.Parse(noteSpawners[random].name.Replace(textToRemoveNote, ""));

            if (randomNoteValue <= remainBudget)
            {
                remainBudget -= randomNoteValue;
                if (random == 0)
                {
                    //Debug.Log("rolled 2dollar note");
                    twoDollarScript.TwoDollarSpawner();
                }
                else if (random == 1)
                {
                   // Debug.Log("rolled 5dollar note");

                    fiveDollarScript.FiveDollarSpawner();
                }
                else if (random == 2)
                {
                   // Debug.Log("rolled 10dollar note");

                    tenDollarScript.TenDollarSpawner();
                }
            }
            else if (remainBudget == 1)
            {
                remainBudget -= 1;
                oneDollarScript.OneDollarSpawner();
            }
        }
    }
    void CoinsRandomise()
    {
        if(coinsBudgetInCents > 0)
        {
         Debug.Log("coins Budget" + coinsBudgetInCents);

            int coinsRandom = Random.Range(0, coinSpawners.Length);
            float randomCoinValue = float.Parse(coinSpawners[coinsRandom].name.Replace(textToRemoveCoin, ""));

            Debug.Log("coins budget left is " + coinsBudgetInCents + "\n random coin value is " + randomCoinValue);

            if(randomCoinValue <= coinsBudgetInCents)
            {
                coinsBudgetInCents -=randomCoinValue;
                if(coinsRandom == 0)
                {
                    fiveCentScript.FiveCentSpawner();
                }
                else if(coinsRandom == 1)
                {
                    tenCentScript.TenCentSpawner();
                }
                else if(coinsRandom == 2)
                {
                    twentyCentScript.TwentyCentSpawner();
                }
                else if(coinsRandom == 3)
                {
                    fiftyCentScript.FiftyCentSpawner();
                }
            }
        }
    }
    
}
