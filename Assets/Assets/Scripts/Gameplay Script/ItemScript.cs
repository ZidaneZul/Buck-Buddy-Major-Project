using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject infoBubble;
    GameObject foodBubbleClone;
    

    GameObject[] foodPoints;
    GameObject tempPoint, pointChildren;
    Vector3 foodBubblePos;
    string pointChildrenString;


    bool didTextSpawn = false;
    bool isPointClose = false;

    // Start is called before the first frame update
    void Start()
    {
        foodPoints = GameObject.FindGameObjectsWithTag("FoodSpawn");   

    }

    // Update is called once per frame
    void Update()
    {
        FindClosePoint();
        IsCloseToFood();
    }

    void FindClosePoint()
    {
        if (!isPointClose)
        {
            foreach (GameObject point in foodPoints)
            {
                if (Vector3.Distance(transform.position, point.transform.position) < 3)
                {
                    tempPoint = point;
                    isPointClose = true;
                    Debug.Log("Found a close point");
                }
            }
        }
    }

    void IsCloseToFood()
    {
        if (isPointClose)
        {
            if (Vector3.Distance(transform.position, tempPoint.transform.position) < 3)
            {
                ShowBubble();
                Debug.Log("Close to " + tempPoint);
            }
            else
            {
                DeleteBubble();
            }
        }
    }
    void ShowBubble()
    {
        //pointChildrenString = tempPoint.GetComponentInChildren<GameObject>().ToString();
        
        pointChildren = tempPoint.transform.GetChild(0).gameObject;
        pointChildrenString = pointChildren.ToString();
        Debug.Log("the child object is " + pointChildren);

        //foodBubblePos.position = new Vector3(pointChildren.transform.position.x, pointChildren.transform.position.y - 1.4f, pointChildren.transform.position.z);
        


        if (!didTextSpawn)
        {
            didTextSpawn = true;

            foodBubblePos = pointChildren.transform.position;
            foodBubblePos.y = pointChildren.transform.position.y - 1.4f;

            foodBubbleClone = Instantiate(infoBubble);
            Debug.Log("Made new bubble");

            foodBubbleClone.transform.position = foodBubblePos;
            Debug.Log("pos of point is " + pointChildren.transform.position + "\n" +
            "pos of food bubble is " + foodBubblePos);

        }
    }

    void DeleteBubble()
    {
        Destroy(foodBubbleClone);
        didTextSpawn=false;
        isPointClose=false;
    }
        
}