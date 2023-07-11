using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject infoBubble;
    GameObject infoBubbleClone;
    Vector3 foodBubblePos;

    GameObject[] foodPoints;
    GameObject tempPoint, pointChildren;
    string pointChildrenString;

    bool didTextSpawn = false;

    Vector3 lowerPadding = new Vector3(0, -5, 0);

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
                Debug.Log("Found a close point");
                //ShowBubble();
                while(Vector3.Distance(transform.position, tempPoint.transform.position) < 3)
                {
                    ShowBubble();
                }
            }
            else
            {
                DeleteBubble();
            }
        }

        //if(Vector3.Distance(transform.position, tempPoint.transform.position) < 3)
        //{
        //    ShowBubble();
        //    Debug.Log("Close to " + tempPoint);
        //}
        //else
        //{
        //    DeleteBubble();
        //}
    }

    void ShowBubble()
    {
        //pointChildrenString = tempPoint.GetComponentInChildren<GameObject>().ToString();
        
        pointChildren = tempPoint.transform.GetChild(0).gameObject;
        pointChildrenString = pointChildren.ToString();
        Debug.Log("the child object is " + pointChildren);

        foodBubblePos = new Vector3 (pointChildren.transform.position.x, pointChildren.transform.position.y - 1.4f, pointChildren.transform.position.z);

        if (!didTextSpawn)
        {
            didTextSpawn = true;
            infoBubbleClone = Instantiate(infoBubble, pointChildren.transform);
        }
    }

    void DeleteBubble()
    {
        Destroy(infoBubbleClone);
        didTextSpawn=false;
    }
        
}
