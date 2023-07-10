using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShelfScript : MonoBehaviour
{
    public Collider[] collidedObjects;
    RaycastHit hit;
    public GameObject UIPopUp;
    public GameObject[] FoodItems;
    public GameObject[] CannedItems;
    public GameObject[] DairyItems;
    public GameObject[] AllItems;
    public Transform[] SpawnWaypoints;
    public string[] ProductName;
    public string[] ProductPrice;
    public List<GameObject> spawnedFood;
    public TextMeshPro ProductTextUI;
    public TextMeshPro ProductPriceUI;
    public GameObject ProductInfo;
    public bool Dairy;
    public bool CannedGoods;



    // Start is called before the first frame update
    void Start()
    {
        ProductInfo = GameObject.FindGameObjectWithTag("ProductInformation");
        ProductTextUI = GameObject.FindGameObjectWithTag("ProductTextBox").GetComponent<TextMeshPro>();
        ProductPriceUI = GameObject.FindGameObjectWithTag("ProductPriceBox").GetComponent<TextMeshPro>();

        if (Dairy == true)
        {
            FoodItems = DairyItems;

            while(spawnedFood.Count < 3)
            {
                for (int i = 0; i < SpawnWaypoints.Length; i++)
                {
                    Physics.Raycast(SpawnWaypoints[i].transform.position, transform.TransformDirection(Vector3.down), out hit, 3f);
                    Physics.Raycast(SpawnWaypoints[i].transform.position, transform.TransformDirection(Vector3.up), out hit, 3f);

                    if(hit.collider == GameObject.FindGameObjectWithTag("Food"))
                    {
                        return;
                    }
                    else
                    {
                        int RandomFoodItem = Random.Range(0, DairyItems.Length);
                        GameObject spawnedOnShelf=Instantiate(DairyItems[RandomFoodItem], SpawnWaypoints[i]);
                        spawnedFood.Add(spawnedOnShelf);
                        
                    }
                }
            }

        }
        if(CannedGoods == true)
        {
            FoodItems = CannedItems;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetection();
    }


    void PlayerDetection()
    {
        for (int i = 0; i < spawnedFood.Count; i++)
        {
            if (Physics.Raycast(spawnedFood[i].transform.position, transform.TransformDirection(Vector3.down), out hit, 3f))
            {
                if (hit.collider == GameObject.FindGameObjectWithTag("Player"))
                {
                    FoodIDScript Holder = spawnedFood[i].GetComponent<FoodIDScript>();
                    for(int k = 0; k < AllItems.Length; k++)
                    {
                        if(k == Holder.FoodID)
                        {
                            ProductTextUI.text = ProductName[k];
                            ProductPriceUI.text = ProductPrice[k];
                            UIPopUp.SetActive(true);
                            UIPopUp.transform.rotation.SetLookRotation(Camera.main.transform.position);
                            UIPopUp.transform.position = new Vector3(spawnedFood[i].transform.position.x, 5f, spawnedFood[i].transform.position.z);
                        }
                    }

                }
            }
            else
            {
                UIPopUp.SetActive(false);
            }
        }

    }


    //void SimilarFood()
    //{
    //    if ()

    //    //for (int i = 0; i < FoodItems.Length; i++)
    //    //{
    //    //    for (int j = 0; j < spawnedFood.Count; j++) 
    //    //    {
    //    //        if(FoodItems[i] == spawnedFood[j])
    //    //        {
    //    //            ProductTextUI.text = ProductName[i];
    //    //            ProductPriceUI.text = ProductPrice[i];
    //    //        }
    //    //    }
    //    //}
    //}

}
