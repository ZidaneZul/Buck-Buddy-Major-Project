using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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
    public GameObject star1, star2, star3;
    public Image star1Image,star2Image,star3Image;
    public TextMeshProUGUI scoreboardText;
    public Sprite[] stars;
    public LevelData levelData;
    public ButtonDataHolder buttonDataHolder;

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

    public GameObject scoreBoard;


    public Image mask;
    public DragDrop dragdrop;

    public Image image;
    public float fillAmount;

    public static List<ItemData> storedData;

    public Animator anim;
    
    
    public void Start()
    {
        buttonDataHolder = GameObject.Find("RandomEventHandler").GetComponent<ButtonDataHolder>();
        star1Image = star1.GetComponent<Image>();
        star2Image = star2.GetComponent<Image>();
        star3Image = star3.GetComponent<Image>();
        placement = GameObject.FindGameObjectsWithTag("Waypoint");
        //originalPlacement = GameObject.FindGameObjectsWithTag("Original Waypoints");     
        anim.enabled = false;
        confirm.interactable = false;

        scoreBoard.SetActive(false);



        //randomNumber = Random.Range(1f, 100f);
        //randomNumber = Mathf.Round((randomNumber * 100.0f) * 0.01f);
        randomNumber = InventoryManager.Instance.totalPrice;
        Debug.Log("random amount: " + randomNumber);
        moneyGenerater.text = "Total: " + randomNumber;

        storedData = InventoryManager.Instance.itemList;
    
    }
    public void Update()
    {
        //Debug.Log(i);
        //Debug.Log("Sum added " + sumAdded);
        //Debug.Log("Magnitude: " + dragdrop.originalPosition.magnitude);
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
            if(sumAdded - randomNumber > 5f)
            {
                image.color = Color.red;
                progressBarText.text = "Too much!";
            }
            else if(sumAdded - randomNumber > 2 && sumAdded - randomNumber < 5)
            {
                image.color = new Color(1, 0.5651493f, 0);
                progressBarText.text = "A little too much!";
            }
            else if(sumAdded == randomNumber)
            {
                image.color = Color.green;
            }
            else
            {
                image.color = Color.yellow;
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

    public void Checker()
    {
        Debug.Log("amount added: " + sumAdded + "\n" + randomNumber);
        Debug.Log("diff in amts" + (sumAdded - randomNumber));
        if (sumAdded == randomNumber)
        {
            scoreBoard.SetActive(true);
            star1Image.sprite = stars[1];
            star2Image.sprite = stars[1];
            star3Image.sprite = stars[1];
            scoreboardText.text = "Perfect! Nice Job";
            foreach (LevelData.LevelDataHolder data in levelData.levelDataHolder)
            {
                if (data.levelNumber == buttonDataHolder.LevelSelected)
                {
                    if(data.levelStarAmount < 3)
                    {
                        levelData.levelDataHolder[data.levelNumber].levelStarAmount = 3;
                    }
                }
            }
        }
        else if (sumAdded - randomNumber < 3f && sumAdded - randomNumber > -3f)
        {
            scoreBoard.SetActive(true);
            star1Image.sprite = stars[1];
            star2Image.sprite = stars[1];
            star3Image.sprite = stars[0];
            scoreboardText.text = "Getting Better! Keep going";
            foreach (LevelData.LevelDataHolder data in levelData.levelDataHolder)
            {
                if (data.levelNumber == buttonDataHolder.LevelSelected)
                {
                    if (data.levelStarAmount < 2)
                    {
                        levelData.levelDataHolder[data.levelNumber].levelStarAmount = 2;
                    }
                }
            }
        }
        else if (sumAdded - randomNumber < 6f && sumAdded - randomNumber > -6)
        {
            scoreBoard.SetActive(true);
            star1Image.sprite = stars[1];
            star2Image.sprite = stars[0];
            star3Image.sprite = stars[0];
            scoreboardText.text = "Nice Try, Keep going!";
            foreach (LevelData.LevelDataHolder data in levelData.levelDataHolder)
            {
                if (data.levelNumber == buttonDataHolder.LevelSelected)
                {
                    if (data.levelStarAmount < 1)
                    {
                        levelData.levelDataHolder[data.levelNumber].levelStarAmount = 1;
                    }
                }
            }
        }
        else
        {
            scoreBoard.SetActive(true);
            star1Image.sprite = stars[0];
            star2Image.sprite = stars[0];
            star3Image.sprite = stars[0];
            scoreboardText.text = "Try Again!";
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
    //used to clear the list before going to the next levels
    public void ClearList()
    {
        storedData.Clear();
    }
}

