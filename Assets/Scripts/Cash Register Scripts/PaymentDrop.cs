using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaymentDrop : MonoBehaviour, IDropHandler
{
    public GameObject[] placement;
    //public GameObject[] originalPlacement;
    int i;
    int j;

    public Text moneyGenerater;
    public float randomNumber;
    public float amountAdded = 0f;

    public float sumAdded;
    public Button confirm;

    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;
    public GameObject fail;
    public void Start()
    {
        placement = GameObject.FindGameObjectsWithTag("Waypoint");
        //originalPlacement = GameObject.FindGameObjectsWithTag("Original Waypoints");

        confirm.interactable = false;

        oneStar.SetActive(false);
        twoStar.SetActive(false);
        threeStar.SetActive(false);
        fail.SetActive(false);


        randomNumber = Random.Range(1f, 100f);
        randomNumber = Mathf.Round((randomNumber * 100.0f) * 0.01f);
        Debug.Log("random amount: " + randomNumber);
        moneyGenerater.text = "Amount Needed: " + randomNumber;
    }
    public void Update()
    {
        //Debug.Log(i);
        //Debug.Log("Sum added " + sumAdded);
    }
    
    
    public void OnDrop(PointerEventData eventData)
    {
       
        Debug.Log("Dropped"); 
        if(eventData.pointerDrag != null)
        {
           //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = placement[i].transform.position;
            //eventData.pointerDrag.GetComponent<RectTransform>().transform.position = originalPlacement[j].transform.position;
            i++;
            j++;

            //Money added
            if(i == placement.Length)
            {
                i = 0;
            }
            if (eventData.pointerDrag.CompareTag("2 Dollar"))
            {
                Debug.Log("added 2 dollars");
                sumAdded += 2f;
            }
            else if (eventData.pointerDrag.CompareTag("5 Dollar"))
            {
                sumAdded += 5f;
            }
            else if(eventData.pointerDrag.CompareTag("10 Dollar"))
            {
                sumAdded += 10f;
            }
            else if (eventData.pointerDrag.CompareTag("50 Dollar"))
            {
                sumAdded += 50f;
            }
            else if (eventData.pointerDrag.CompareTag("100 Dollar"))
            {
                sumAdded += 100f;
            }
            else if(eventData.pointerDrag.CompareTag("1 Dollar"))
            {
                sumAdded += 1f;
            }
            else if (eventData.pointerDrag.CompareTag("5 Cents"))
            {
                sumAdded += 0.05f;
            }
            else if (eventData.pointerDrag.CompareTag("10 Cents"))
            {
                sumAdded += 0.1f;
            }
            else if (eventData.pointerDrag.CompareTag("20 Cents"))
            {
                sumAdded += 0.2f;
            }
            else if (eventData.pointerDrag.CompareTag("50 Cents"))
            {
                sumAdded += 0.5f;
            }

            confirm.interactable = true;

            
            //Money Subtracted
        }


        
    }

    public void Checker()
    {
        Debug.Log("amount added: " + sumAdded + "\n" + randomNumber);
        Debug.Log("diff in amts" + (sumAdded - randomNumber));
        if (sumAdded == randomNumber)
        {
            threeStar.SetActive(true);
            twoStar.SetActive(false);
            oneStar.SetActive(false);
        }
        else if (sumAdded - randomNumber < 3f && sumAdded - randomNumber > -3f)
        {
            threeStar.SetActive(false);
            oneStar.SetActive(false);
            twoStar.SetActive(true);
        }
        else if (sumAdded - randomNumber < 6f && sumAdded - randomNumber > -6)
        {
            threeStar.SetActive(false);
            oneStar.SetActive(true);
            twoStar.SetActive(false);
        }
        else 
        {
            fail.SetActive(true);
            oneStar.SetActive(false);
            twoStar.SetActive(false);
            threeStar.SetActive(false);
        }
    }
}
