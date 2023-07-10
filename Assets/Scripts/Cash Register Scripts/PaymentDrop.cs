using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaymentDrop : MonoBehaviour, IDropHandler
{
    public GameObject[] placement;
    int i;

    public Text moneyGenerater;
    float randomNumber;

    float sumAdded;

    public GameObject tenDollar;
    public void Start()
    {
        placement = GameObject.FindGameObjectsWithTag("Waypoint");
        
        randomNumber = Random.Range(1f, 200f);
        randomNumber = Mathf.Round(randomNumber * 100.0f) * 0.01f;
        moneyGenerater.text = "Amount Left: " + randomNumber;
    }
    public void Update()
    {
        Debug.Log(i);
        Debug.Log("Sum added " + sumAdded);
        moneyGenerater.text = "Amount Left: " + (randomNumber - sumAdded );
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped"); 
        if(eventData.pointerDrag != null)
        {
           //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = placement[i].transform.position;
            i++;

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

        }


        
    }
}
