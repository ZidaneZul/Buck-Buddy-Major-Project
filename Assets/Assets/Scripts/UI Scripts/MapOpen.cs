using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MapOpen : MonoBehaviour
{
    public GameObject panel, player, buttonPressed, shoppingCartPanel, shoppingList, dynamicShoppingList
        , objPanel, helpPanelCtnBtn, MoveButtonLeft, MoveButtonRight, budgetRemainderPanel;
    public GameObject[] waypoints;
    public DialogueHandler dialogueHandler;
    public TextMeshProUGUI helpPanelBody_Txt, budgetReminder_Txt;

    public MapLocation mapLocationScript;

    public Sprite maleHead, femaleHead;
    public GameObject selectedHead;
    public bool isMaleTest;
    bool isActive,shoppingCartActive,cartActive;
    public  PlayerSelectOption selectedModelScript;

    string waypointString, buttonName;
    string[] aisles = { "Rice", "Drink", "Fruit", "Bakery", "Snack", "Canned", "Frozen", "Dairy", "Meat"};
    GameObject[] aislePoint;

    void Start()
    {
        aislePoint = GameObject.FindGameObjectsWithTag("AisleTpButton");
        panel.SetActive(false);


        shoppingCartPanel.SetActive(false);

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        player = GameObject.FindGameObjectWithTag("Player");
        shoppingList.SetActive(false);

        objPanel.SetActive(false);

        selectedModelScript = GameObject.Find("RandomEventHandler").GetComponent<PlayerSelectOption>();
        if (selectedModelScript.isMale)
        {
            selectedHead.GetComponent<Image>().sprite = maleHead;
        }
        else selectedHead.GetComponent<Image>().sprite = femaleHead;

    }
    private void Update()
    {
        if (!shoppingCartPanel.activeInHierarchy)
        {
            InventoryManager.Instance.CleanList();
        }
        else
        {
            shoppingList.SetActive(false);
        }

        BudgetReminder();
        ShowMainShoppingList();
    }
    public void ShowMainShoppingList()
    {
        if(panel.activeInHierarchy || shoppingCartPanel.activeInHierarchy)
        {
            shoppingList.SetActive(true);
        }
        else shoppingList.SetActive(false);
    }
    public void OpenPanel()
    {
        
        if (panel != null)
        {
            bool isActive = panel.activeInHierarchy;

            panel.SetActive(!isActive);
            MoveButtonLeft.SetActive(isActive);
            MoveButtonRight.SetActive(isActive);
            shoppingCartPanel.SetActive(false);
            dynamicShoppingList.SetActive(isActive);


            foreach (GameObject button in aislePoint)
            {
                Debug.Log("Goin thru buttons");
               // Debug.LogWarning("the player is in " + mapLocationScript.FindPlayer().Replace(" ","") +
             //       "\n buttun name is " + button.name);

                if (button.name.Replace("_Btn", "").Contains(mapLocationScript.FindPlayer().Replace(" ", "")))
                {
                    selectedHead.transform.position = button.transform.position;
                    Debug.Log("Head now on button");
                }
            }

            
        }
    }
    public void ToggleCartPanel()
    {
        Debug.Log("Clicked the cart btn");
        if (shoppingCartPanel != null)
        {
            bool cartActive = shoppingCartPanel.activeInHierarchy;
            shoppingCartPanel.SetActive(!cartActive);
            MoveButtonLeft.SetActive(cartActive);
            MoveButtonRight.SetActive(cartActive);
            panel.SetActive(false);
            dynamicShoppingList.SetActive(cartActive);
        }
        
        InventoryManager.Instance.ShowItem();
    }

    public void CheckOut()
    {
        if (InventoryManager.Instance.budget < 0)
        {
            objPanel.SetActive(true);
            helpPanelCtnBtn.SetActive(false);
            helpPanelBody_Txt.text = "Hey! You are over budget! Remove items you don't need! " +
                "\n $" + Mathf.Abs(InventoryManager.Instance.budget).ToString("F2") + " over!";


        }
        else if (InventoryManager.Instance.CheckForObj())
                     SceneManager.LoadScene("CashRegister");
        else
        {
            objPanel.SetActive(true);
            helpPanelCtnBtn.SetActive(true);
            helpPanelBody_Txt.text = "Hey! You have missing items from your shopping list!";

            panel.SetActive(false);
            shoppingCartPanel.SetActive(false);
        }
    }

    public void GetHelpForMissingCart()
    {
        helpPanelBody_Txt.text = InventoryManager.Instance.FindMissingItems();
;
        helpPanelCtnBtn.SetActive(false);


    }

    public void TeleportToAisleDynamic()
    {
        buttonPressed = EventSystem.current.currentSelectedGameObject;
        buttonName = buttonPressed.ToString();

        foreach (string aisle in aisles)
        {
            if (buttonName.Contains(aisle))
            {
                for (int i = 0; i < waypoints.Length; i++)
                {
                    waypointString = waypoints[i].ToString();

                    if (waypointString.Contains(aisle))
                    {
                        player.transform.position = waypoints[i].transform.position;
                        panel.SetActive(false);
                        MoveButtonLeft.SetActive(true);
                        MoveButtonRight.SetActive(true);
                    }
                }
            }
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
    public void CloseObjPanel()
    {
        objPanel.SetActive(false);
        MoveButtonLeft.SetActive(true);
        MoveButtonRight.SetActive(true);
    }

    public void BudgetReminder()
    {
        if(InventoryManager.Instance.budget < 0)
        {
            budgetRemainderPanel.SetActive(true);
            budgetReminder_Txt.text = "You are over budget! Please return items! " +
                "\n $" + Mathf.Abs(InventoryManager.Instance.budget) + " over!";
            budgetReminder_Txt.color = Color.red;
        }
        else if (InventoryManager.Instance.budget <= 5)
        {
            budgetRemainderPanel.SetActive(true);
            budgetReminder_Txt.text = "Hey! You're cutting it close to the budget! " +
                "\n $" + InventoryManager.Instance.budget.ToString("F2") + " left!";
            budgetReminder_Txt.color = Color.yellow;
        }
        else
        {
            budgetRemainderPanel.SetActive(false);
        }
    }
}