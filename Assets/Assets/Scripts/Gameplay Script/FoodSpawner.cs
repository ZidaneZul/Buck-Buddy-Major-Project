using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodSpawner : MonoBehaviour
{
    GameObject player;

    GameObject[] SpawnPoints;

    public GameObject infoBubble, bubble;

    TextMeshPro textMeshPro;

    bool DidTextSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SpawnPoints = GameObject.FindGameObjectsWithTag("FoodSpawn");

        
    }

    // Update is called once per frame
    void Update()
    {
        ReadyPopUp(3);
        Debug.Log(SpawnPoints.Length);
        DeleteBubble();
    }

    void ReadyPopUp(float distance)
    {
        foreach (GameObject spawn in SpawnPoints)
        {
            //Debug.Log(Vector3.Distance(transform.position, spawn.transform.position));
            if (Vector3.Distance(player.transform.position, spawn.transform.position) < distance && !DidTextSpawn)
            {
                Debug.Log("CLOSE! BUY ME");
                bubble = Instantiate(infoBubble,spawn.transform);

                ChangeText("Bread", "5");
                DidTextSpawn = true;
            }
            
        }
    }

    void ChangeText(string name, string price)
    {
        textMeshPro = GameObject.Find("FoodInfo_Text").GetComponent<TextMeshPro>();
        textMeshPro.SetText(name + "\n" + "$" + price);
    }

    void DeleteBubble()
    {
        if (Vector3.Distance(bubble.transform.position, player.transform.position) > 3)
        {
            Destroy(bubble);
            DidTextSpawn=false; 
        }
    }
}
