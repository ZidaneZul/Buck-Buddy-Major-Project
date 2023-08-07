using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject infoBubble;
    GameObject foodBubbleClone;
    

    GameObject[] foodPoints;
    GameObject tempPoint; //tempPoint is to store the waypoint gameobject to use.
    Vector3 foodBubblePos;
    public bool talkingToNPC;
    public GameObject dialogueBox;

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
        if (dialogueBox.activeInHierarchy)
        {
            talkingToNPC = true;
        }
        else
        {
            talkingToNPC=false;
        }
        FindClosePoint();
        IsCloseToFood();
        //Debug.DrawRay(tempPoint.transform.position, transform.TransformDirection(Vector3.down) * 2.5f, Color.red);

    }

    void FindClosePoint()
    {
        if (!isPointClose)
        {
            foreach (GameObject point in foodPoints)
            {
                RaycastHit hit;

                Vector3 LinePoint = new Vector3 ( point.transform.position.x, point.transform.position.y - 2.5f, point.transform.position.z);
                Debug.DrawLine(point.transform.position, LinePoint) ;
                if (Physics.Raycast(point.transform.position, transform.TransformDirection(Vector3.down),out hit, 2.5f))
                {
                    tempPoint = point;
                    isPointClose = true;
                    Debug.Log(hit.collider.name);
                   // Debug.Log("Found a close point");
                }

            }
        }
    }

    void IsCloseToFood()
    {
        if (isPointClose && !talkingToNPC)
        {
            //Debug.Log(Vector3.Distance(transform.position, tempPoint.transform.position));
            if (Vector3.Distance(transform.position, tempPoint.transform.position) < 2.5)
            {
                ShowBubble();
                //Debug.Log("Close to " + tempPoint);
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
        
        //Debug.Log("the child object is " + pointChildren);

        //foodBubblePos.position = new Vector3(pointChildren.transform.position.x, pointChildren.transform.position.y - 1.4f, pointChildren.transform.position.z);
        


        if (!didTextSpawn)
        {
            didTextSpawn = true;

            foodBubblePos = tempPoint.transform.position;

            //if (!CheckForFloor())
            //{
            //    foodBubblePos.y = tempPoint.transform.position.y - 1.8f;
            //}
            //else
            //{
                foodBubblePos.y = gameObject.transform.position.y + 4.5f;
            //}

            foodBubbleClone = Instantiate(infoBubble);
           // Debug.Log("Made new bubble");

            foodBubbleClone.transform.position = foodBubblePos;
            //Debug.Log("pos of point is " + pointChildren.transform.position + "\n" +
            //"pos of food bubble is " + foodBubblePos);

        }
    }

    void DeleteBubble()
    {
        Destroy(foodBubbleClone);
        didTextSpawn=false;
        isPointClose=false;
    }

    //bool CheckForFloor()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(tempPoint.transform.position, transform.TransformDirection(Vector3.down), out hit, 2.5f))
    //    {
    //        Debug.Log("The bubble would hit the thing below foodpoint");
    //        return true;
    //    }
    //    else return false;
    //}
        
}
