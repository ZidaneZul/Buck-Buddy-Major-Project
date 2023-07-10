using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    GameObject[] foodPoints;
    GameObject tempPoint, pointChildren;
    string pointChildrenString;

    // Start is called before the first frame update
    void Start()
    {
        foodPoints = GameObject.FindGameObjectsWithTag("FoodSpawn");   

    }

    // Update is called once per frame
    void Update()
    {
        IsClose();

    }

    void IsClose()
    {
        foreach (GameObject point in foodPoints)
        {
            if (Vector3.Distance(transform.position, point.transform.position) < 3)
            {
                tempPoint = point;
                Debug.Log("Close to point!");
            }
        }
    }

    void ShowBubble()
    {
        pointChildrenString = tempPoint.GetComponentInChildren<GameObject>().ToString();
        


    }
}
