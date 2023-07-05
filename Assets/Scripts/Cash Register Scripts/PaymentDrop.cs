using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaymentDrop : MonoBehaviour, IDropHandler
{
    public GameObject[] placement;
    int i;
    public void Start()
    {
        placement = GameObject.FindGameObjectsWithTag("Waypoint");
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
        }
    }
}
