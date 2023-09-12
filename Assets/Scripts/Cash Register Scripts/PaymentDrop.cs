using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PaymentDrop : MonoBehaviour, IDropHandler
{
    //Variables (Placement and activeMoney Variables)
    public GameObject[] placement;
    public List<GameObject> activeMoney; 

    //All the coins and money put in a list and converted into gameobject variables to use for later.
    public List<GameObject> twoDollar;
    public List<GameObject> fiveDollar;
    public List<GameObject> tenDollar;
    public List<GameObject> fiftyDollar;
    public List<GameObject> hundredDollar;
    public List<GameObject> oneDollar;
    public List<GameObject> fiveCent;
    public List<GameObject> tenCent;
    public List<GameObject> twentyCent;
    public List<GameObject> fiftyCent;

    public Vector3 cashDropPos;
    public float offset;
    //public GameObject[] originalPlacement;
    int i;
    int j;

    //More Variables
    public Text moneyGenerater;
    public Text progressBarText;
    public float randomNumber;
    public float amountAdded = 0f;
    public float sumAdded;
    public Button confirm;

    //for the endgame of the cash register
    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;
    public GameObject fail;

    public Image mask;
    public DragDrop dragdrop;

    public Image image;
    public float fillAmount;

    public static List<ItemData> storedData;

    public Animator anim;
    
    
    public void Start()
    {
        //Finding gameobject components using its Tag called waypoint
        placement = GameObject.FindGameObjectsWithTag("Waypoint");
        //originalPlacement = GameObject.FindGameObjectsWithTag("Original Waypoints");     
        
        //Variables for animation set to false first because I want to activate it later
        anim.enabled = false;
        //This is for the confirm button in the Cash Register
        confirm.interactable = false;

        //This is for the popup gameobject for the 3 stars to show how well the player did
        oneStar.SetActive(false);
        twoStar.SetActive(false);
        threeStar.SetActive(false);
        fail.SetActive(false);

        
        //randomNumber = Random.Range(1f, 100f);
        //randomNumber = Mathf.Round((randomNumber * 100.0f) * 0.01f);
        randomNumber = InventoryManager.Instance.totalPrice;
        Debug.Log("random amount: " + randomNumber);
        moneyGenerater.text = "Total: " + randomNumber;

        //Called Inventory Manager Script needed to call for later use in the script.
        storedData = InventoryManager.Instance.itemList;
    
    }
    public void Update()
    {
        //Debug.Log(i);
        //Debug.Log("Sum added " + sumAdded);
        //Debug.Log("Magnitude: " + dragdrop.originalPosition.magnitude);
    }
    
    //This method is when the player drops the money inside a payment gameobject that is set in the scene.
    //Right now the gameobject's alpha has been set to 0 and cannot be seen.
    
    public void OnDrop(PointerEventData eventData)
    {
      
       //Rest of this code is what happens when you drop the coins and money into the placement gameobjects.
       //Different Functions for each coin and notes set. 
        Debug.Log("Dropped"); 
        if(eventData.pointerDrag != null)
        {
           //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = placement[i].transform.position;
            //eventData.pointerDrag.GetComponent<RectTransform>().transform.position = originalPlacement[j].transform.position;
            i++;
            j++;

            //This is to reset the placement the incremented i becomes equal to the placements Length which is set as a list
            //Money added
            if(i == placement.Length)
            {
                i = 0;
            }

            //The rest of this code based on adding to the total amount of money when the player drags into the payment system.// 

            //This part of the code is what adds the values of each note and coin together using Tags.
       
            if (eventData.pointerDrag.CompareTag("2 Dollar")) //This looks for the gameobject that is being dragged with the tag 2 dollars.
            {
                Debug.Log("added 2 dollars"); 
                twoDollar.Add(eventData.pointerDrag); //This adds twodollar to the list that is made peviously 
                foreach(GameObject point in placement) //Used a foreach loop to check for placements in a certain area to place the 2 dollar game object.
                {
                    if (point.ToString().Contains("2DollarCP")) //Looks for the position of a gameobject with 2 Dollar CP
                    {
                        cashDropPos = point.transform.position; //When the player drags, it goes to this position 
                        offset = twoDollar.Count * 14; //NOT IN USE ANYMORE, was initially to move the note sideways using an offset of 14
                        cashDropPos.y -= offset; //This is where the note would move if dragged in
                        eventData.pointerDrag.transform.position = cashDropPos; //So the 2 dollars would stack upon each other
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 2f; //This is to add the amount which is dollars in this case
            }

            //The next codes are the SAME EXPLANATION AS THE DOLLARS UNTIL THE FINISHED LINE
            else if (eventData.pointerDrag.CompareTag("5 Dollar"))
            {
                fiveDollar.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("5DollarCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = fiveDollar.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 5f;
            }
            else if(eventData.pointerDrag.CompareTag("10 Dollar"))
            {
                tenDollar.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("10DollarCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = tenDollar.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 10f;
            }
            else if (eventData.pointerDrag.CompareTag("50 Dollar"))
            {
                fiftyDollar.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("50DollarCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = fiftyDollar.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 50f;
            }
            else if (eventData.pointerDrag.CompareTag("100 Dollar"))
            {
                fiftyDollar.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("100DollarCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = hundredDollar.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 100f;
            }
            else if(eventData.pointerDrag.CompareTag("1 Dollar"))
            {
                oneDollar.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("1DollarCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = oneDollar.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 1f;
            }
            else if (eventData.pointerDrag.CompareTag("5 Cents"))
            {
                fiveCent.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("5cCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = fiveCent.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 0.05f;
            }
            else if (eventData.pointerDrag.CompareTag("10 Cents"))
            {
                tenCent.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("10cCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = tenCent.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 0.1f;
            }
            else if (eventData.pointerDrag.CompareTag("20 Cents"))
            {
                twentyCent.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("20cCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = twentyCent.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 0.2f;
            }
            else if (eventData.pointerDrag.CompareTag("50 Cents"))
            {
                fiftyCent.Add(eventData.pointerDrag);
                foreach (GameObject point in placement)
                {
                    if (point.ToString().Contains("50cCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = fiftyCent.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 0.5f;
            }

            //FINISHED//


            confirm.interactable = true; // This is for the confirm button when the user pays a certain amount the button will activate.

            GetCurrentFill(); //Progress Bar method called in the drag in method. 
            progressBarText.text = "" + sumAdded;
            //Money Subtracted
            //Prgress bar color change methods using If Statements
            if(sumAdded - randomNumber > 5f)  //if the sum added for the amount the player drags in minus the randomNumber is less than 5 
            {
                image.color = Color.red; //The color of the progres bar will change to red.
                progressBarText.text = "Too much!";
            }
            else if(sumAdded - randomNumber > 2 && sumAdded - randomNumber < 5) //This else if statement is a range. if the sumadded - random number is in between the values of 2 and 5 it changes to orange color
            {
                image.color = new Color(1, 0.5651493f, 0);
                progressBarText.text = "A little too much!";
            }
            else if(sumAdded == randomNumber) //If sumadded is equal to random number then the progress barr will become green
            {
                image.color = Color.green;
            }
            else
            {
                image.color = Color.yellow; //The default color of progress bar when dragging in notes is yellow.
            }

            if(sumAdded == randomNumber)
            {
                anim.enabled = true;
            }
            else
            {
                anim.enabled = false;
            }
        }


        
    }


    //Checker Method to check whether the player deserves a 1,2 or 3 star for that certain level.
    public void Checker()
    {
        Debug.Log("amount added: " + sumAdded + "\n" + randomNumber);
        Debug.Log("diff in amts" + (sumAdded - randomNumber));
        if (sumAdded == randomNumber) //If the sum added is equals to the random number, All the stars will be set to active. Hence, why 3 stars is true
        {
            threeStar.SetActive(true);
            twoStar.SetActive(false);
            oneStar.SetActive(false);
        }
        else if (sumAdded - randomNumber < 3f && sumAdded - randomNumber > -3f) //For 2 star, the player has to go over 3 and below 3 then the player will get a 3 star
        {
            threeStar.SetActive(false);
            oneStar.SetActive(false);
            twoStar.SetActive(true);
        }
        else if (sumAdded - randomNumber < 6f && sumAdded - randomNumber > -6) //For 1 star the player has to go over 6 and below 6
        {
            threeStar.SetActive(false);
            oneStar.SetActive(true);
            twoStar.SetActive(false);
        }
        else //Else the player will fail
        {
            fail.SetActive(true);
            oneStar.SetActive(false);
            twoStar.SetActive(false);
            threeStar.SetActive(false);
        }
    }

    //This is for the progress bar for the filling in function using a mask component added to the game object. 
    public void GetCurrentFill()
    {
        fillAmount = (float)sumAdded / (float)randomNumber;
        mask.fillAmount = fillAmount;

       
    }

    //This is for the reset button and it has been made into a method
    public void ResetCash()
    {
        //It checks for every gameobject inside the list cash.
        foreach(GameObject cash in activeMoney)
        {
            dragdrop = cash.GetComponent<DragDrop>();//Gets the cash component
            cash.transform.position = dragdrop.originalPosition; //and drops the in their original position.
        }

        //For the progress bar to reset and go back to 0 along with the mask
        sumAdded = 0; 
        progressBarText.text = "" + sumAdded;
        mask.fillAmount = 0;

        //Clears the list 
        twoDollar.Clear();
        fiveDollar.Clear();
        tenDollar.Clear();
        fiveCent.Clear();
        tenCent.Clear();
        twentyCent.Clear();
        fiftyCent.Clear();
        oneDollar.Clear();
      
      
    }
    //used to clear the list before going to the next levels
    public void ClearList()
    {
        storedData.Clear();
    }
}

