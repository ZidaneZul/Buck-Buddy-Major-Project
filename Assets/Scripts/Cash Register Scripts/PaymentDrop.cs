using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaymentDrop : MonoBehaviour, IDropHandler
{
    public GameObject[] placement;
    public List<GameObject> activeMoney;

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

    public Text moneyGenerater;
    public Text progressBarText;
    public float randomNumber;
    public float amountAdded = 0f;

    public float sumAdded;
    public Button confirm;

    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;
    public GameObject fail;

    public Image mask;
    public DragDrop dragdrop;

    public float fillAmount;
    
    
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
        moneyGenerater.text = "Cost of Items: " + randomNumber;
    }
    public void Update()
    {
        //Debug.Log(i);
        //Debug.Log("Sum added " + sumAdded);
        Debug.Log("Magnitude: " + dragdrop.originalPosition.magnitude);
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
                twoDollar.Add(eventData.pointerDrag);
                foreach(GameObject point in placement)
                {
                    if (point.ToString().Contains("2DollarCP"))
                    {
                        cashDropPos = point.transform.position;
                        offset = twoDollar.Count * 14;
                        cashDropPos.y -= offset;
                        eventData.pointerDrag.transform.position = cashDropPos;
                    }
                }
                activeMoney.Add(eventData.pointerDrag);
                sumAdded += 2f;
            }
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

            confirm.interactable = true;

            GetCurrentFill();
            progressBarText.text = "" + sumAdded;
            //Money Subtracted
            if (sumAdded - randomNumber > 5f)
            {
                progressBarText.text = "Too much!";
            }

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

    public void GetCurrentFill()
    {
        fillAmount = (float)sumAdded / (float)randomNumber;
        mask.fillAmount = fillAmount;

       
    }

    public void ResetCash()
    {
        foreach(GameObject cash in activeMoney)
        {
            dragdrop = cash.GetComponent<DragDrop>();
            cash.transform.position = dragdrop.originalPosition;
        }

        sumAdded = 0;
        progressBarText.text = "" + sumAdded;
        mask.fillAmount = 0;

        twoDollar.Clear();
        fiveDollar.Clear();
        tenDollar.Clear();
        fiveCent.Clear();
        tenCent.Clear();
        twentyCent.Clear();
        fiftyCent.Clear();
        oneDollar.Clear();
      
      
    }
}

