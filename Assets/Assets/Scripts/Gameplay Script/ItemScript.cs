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
    public GameObject tutorialBox;

    public bool didTextSpawn = false;
    public bool isPointClose = false;
    bool testingGizmos = false;
    bool otherFoodBubbleOpen = false;
    bool foodBubbleClicked = false;
    bool spawnerClicked=false;
    bool close = false; 

    Vector3 boxSize = new Vector3(1.7f, 1.5f, 2);



    // Start is called before the first frame update
    void Start()
    {
        foodPoints = GameObject.FindGameObjectsWithTag("FoodSpawn");
        tutorialBox = GameObject.FindGameObjectWithTag("Tutorial");
        testingGizmos = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(foodBubbleClone != null)
        {
            foodBubbleClone.transform.position = foodBubblePos;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "FoodSpawn")
                {
                    spawnerClicked = !spawnerClicked;
                }
                if (hit.transform.gameObject.tag != "FoodBubble")
                {
                    foodBubbleClicked = !foodBubbleClicked;
                    
                }

            }
        }

        if (dialogueBox.activeInHierarchy)
        {
            talkingToNPC = true;
        }
        else
        {
            talkingToNPC=false;
        }

        
        // FindClosePoint();
        // IsCloseToFood();
        // FindPlayer();

    }

    void FindPlayer()
    {
        Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, boxSize);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player") && !talkingToNPC)
            {
                Debug.Log("Showing bubble");
                Debug.LogWarning(didTextSpawn);
                ShowBubble();
            }
            else
            {
                Debug.LogWarning("Deleting bubble");
                Debug.Log("HELP");
                DeleteBubble();
            }
        }
    }

    private void OnMouseUpAsButton()
    {

        if(talkingToNPC || tutorialBox.activeInHierarchy || otherFoodBubbleOpen)
        {
            return;
        }
        else
        {
            if (!spawnerClicked)
            {
                ShowBubble();
            }
            if (foodBubbleClicked)
            {
                DeleteBubble();
            }
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !talkingToNPC)
        {
            otherFoodBubbleOpen = true;
            ShowBubble();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        otherFoodBubbleOpen = false;
        DeleteBubble();
    }
    private void OnDrawGizmos()
    {
        if (testingGizmos)
        {
            Gizmos.DrawWireCube(transform.position, boxSize * 2);

        }
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
    public void ShowBubble()
    {
        if (!didTextSpawn)
        {
            Debug.Log("Spawn bubble!");
            didTextSpawn = true;

            foodBubblePos = transform.position;

            foodBubblePos.y = gameObject.transform.position.y + 2.5f;

            foodBubbleClone = Instantiate(infoBubble);
            Debug.LogWarning("Food bubble is now in" + foodBubbleClone.transform.position);

            foodBubbleClone.transform.position = foodBubblePos;
       



        }
    }

    public void DeleteBubble()
    {
        Destroy(foodBubbleClone);
        didTextSpawn=false;
        isPointClose=false;
    }
        
}
