using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MapOpen : MonoBehaviour
{
    public GameObject panel, player, buttonPressed, shoppingCartPanel, shoppingList
        , objPanel, helpPanelCtnBtn, MoveButtonLeft, MoveButtonRight;
    public GameObject[] waypoints;
    public DialogueHandler dialogueHandler;

    public TextMeshProUGUI helpPanelBody_Txt;

    MapLocation mapLocationScript;

    public Sprite maleHead, femaleHead;
    public GameObject selectedHead;
    public bool isMaleTest;

    string waypointString, buttonName;
    string[] aisles = { "Rice", "Drink", "Fruit", "Bakery", "Snack", "Canned", "Frozen", "Dairy", "Meat"};
    GameObject[] aislePoint;

    void Start()
    {
        panel = GameObject.Find("Map");
        aislePoint = GameObject.FindGameObjectsWithTag("AisleTpButton");
        selectedHead = GameObject.Find("Head_Img");
        panel.SetActive(false);

        shoppingCartPanel = GameObject.Find("Cart_Panel");
        shoppingCartPanel.SetActive(false);
        Debug.Log("Shopping cart closeeeee");

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        player = GameObject.FindGameObjectWithTag("Player");
        shoppingList = GameObject.Find("ShoppingList");
        MoveButtonLeft = GameObject.Find("MoveLeft");
        MoveButtonRight = GameObject.Find("MoveRight");
        shoppingList.SetActive(false);

        objPanel = GameObject.Find("LevelObj_Panel");
        helpPanelBody_Txt = GameObject.Find("BodyHelpPanel_Txt").GetComponent<TextMeshProUGUI>();

        helpPanelCtnBtn = GameObject.Find("Hint_Btn");

        mapLocationScript = GameObject.Find("GameManager").GetComponent<MapLocation>();

        objPanel.SetActive(false);

        if (isMaleTest)
        {
            selectedHead.GetComponent<Image>().sprite = maleHead;
        }
        else selectedHead.GetComponent<Image>().sprite = femaleHead;

    }
    private void Update()
    {
        if (panel.activeInHierarchy || shoppingCartPanel.activeInHierarchy)
        {
            shoppingList.SetActive(true);
        }
        else
        {
            shoppingList.SetActive(false);
        }
        if (!shoppingCartPanel.activeInHierarchy)
        {
            InventoryManager.Instance.CleanList();
        }
    }
    public void OpenPanel()
    {
        
        if (panel != null)
        {
            
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
            MoveButtonLeft.SetActive(isActive);
            MoveButtonRight.SetActive(isActive);
            shoppingCartPanel.SetActive(false);
            foreach(GameObject button in aislePoint)
            {
                if (mapLocationScript.FindPlayer().Contains(button.name))
                {
                    selectedHead = button.transform.position;
                }
            }

            
        }
    }
    public void ToggleCartPanel()
    {
        Debug.Log("Clicked the cart btn");
        if (shoppingCartPanel != null)
        {
            bool cartActive = shoppingCartPanel.activeSelf;
            shoppingCartPanel.SetActive(!cartActive);
            MoveButtonLeft.SetActive(cartActive);
            MoveButtonRight.SetActive(cartActive);
            panel.SetActive(false);
        }
        
        InventoryManager.Instance.ShowItem();
    }

    public void CheckOut()
    {
        if(InventoryManager.Instance.CheckForObj())
            SceneManager.LoadScene("CashRegister");
        else
        {
            objPanel.SetActive(true);
            helpPanelCtnBtn.SetActive(true);
            helpPanelBody_Txt.text = "Hey! You have missing items from your shopping list test test!";

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
        MoveButtonLeft.SetActive(true);
        MoveButtonRight.SetActive(true);
        buttonPressed = EventSystem.current.currentSelectedGameObject;
        buttonName = buttonPressed.ToString();


        //Debug.Log("Button name" + buttonName);

        foreach (string aisle in aisles)
        {
            //Debug.Log("Checking for keywords");
            if (buttonName.Contains(aisle))
            {
               // Debug.Log("The button contains keyword" + aisle);
                for (int i = 0; i < waypoints.Length; i++)
                {

                    waypointString = waypoints[i].ToString();
                   // Debug.Log("the string for waypoint is " + waypointString);
                    if (waypointString.Contains(aisle))
                    {
                        //Debug.Log("TP to " + waypointString);
                        player.transform.position = waypoints[i].transform.position;
                        panel.SetActive(false);
                        

                    }
                }
            }
        }

    }
}