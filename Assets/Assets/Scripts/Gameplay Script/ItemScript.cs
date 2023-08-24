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

    Vector3 boxSize = new Vector3(1, 2, 2);

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
    }

    void FindClosePoint()
    {
        if (!isPointClose)
        {
            foreach (GameObject point in foodPoints)
            {
                RaycastHit hit;

                Vector3 LinePoint = new Vector3 ( point.transform.position.x, point.transform.position.y
                    - 2.5f, point.transform.position.z);
                Debug.DrawLine(point.transform.position, LinePoint) ;

                Debug.Log(Vector3.Distance(point.transform.position, transform.position));

//                if (Physics.Raycast(point.transform.position, transform.TransformDirection(Vector3.down),out hit, 2.5f))
                if (Vector3.Distance(transform.position, point.transform.position) < 2.2)
                {
                    tempPoint = point;
                    isPointClose = true;

                }

            }
        }
    }

    void IsCloseToFood()
    {
        if (isPointClose && !talkingToNPC)
        {
            if (Vector3.Distance(transform.position, tempPoint.transform.position) < 2.2)
            {
                ShowBubble();
            }
            else
            {
                DeleteBubble();
            }
        }
    }
    void ShowBubble()
    {
        if (!didTextSpawn)
        {
            didTextSpawn = true;

            foodBubblePos = tempPoint.transform.position;

            foodBubblePos.y = gameObject.transform.position.y + 4.5f;

            foodBubbleClone = Instantiate(infoBubble);

            foodBubbleClone.transform.position = foodBubblePos;
          
        }
    }

    void DeleteBubble()
    {
        Destroy(foodBubbleClone);
        didTextSpawn=false;
        isPointClose=false;
    }
        
}
