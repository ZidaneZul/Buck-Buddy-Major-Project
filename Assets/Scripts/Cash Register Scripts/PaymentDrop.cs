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

    public GameObject tenDollar;
    public void Start()
    {
        placement = GameObject.FindGameObjectsWithTag("Waypoint");
        randomNumber = Random.Range(1, 100);
        moneyGenerater.text = "Amount Left: " + randomNumber;
    }
    public void Update()
    {
        Debug.Log(i);
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
        }

        
    }
}
