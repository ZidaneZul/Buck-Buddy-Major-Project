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
    public void Start()
    {
        placement = GameObject.FindGameObjectsWithTag("Waypoint");
        //originalPlacement = GameObject.FindGameObjectsWithTag("Original Waypoints");

        confirm.interactable = false;

        oneStar.SetActive(false);
        twoStar.SetActive(false);
        threeStar.SetActive(false);


        randomNumber = Random.Range(1f, 100f);
        randomNumber = Mathf.Round((randomNumber * 100.0f) * 0.01f);
        Debug.Log("random amount: " + randomNumber);
        moneyGenerater.text = "Amount Left: " + amountAdded;
    }
    public void Update()
    {
        //Debug.Log(i);
        //Debug.Log("Sum added " + sumAdded);
        moneyGenerater.text = "Total Amount: " + (amountAdded + sumAdded);
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
        if (amountAdded == randomNumber)
        {
            threeStar.SetActive(true);
            twoStar.SetActive(false);
            threeStar.SetActive(false);
        }
        else if (amountAdded - randomNumber < 3f)
        {
            threeStar.SetActive(false);
            twoStar.SetActive(true);
            threeStar.SetActive(false);
        }
        else if (amountAdded - randomNumber < 6f)
        {
            threeStar.SetActive(false);
            twoStar.SetActive(false);
            threeStar.SetActive(true);
        }
        else
        {
            oneStar.SetActive(false);
            twoStar.SetActive(false);
            threeStar.SetActive(false);
        }
    }
}
