using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapOpen : MonoBehaviour
{
    public GameObject panel, player, buttonPressed, shoppingCartPanel, shoppingList;
    public GameObject[] waypoints;
    public DialogueHandler dialogueHandler;
    

    string waypointString, buttonName;
    string[] aisles = { "Rice", "Drink", "Fruit", "Bakery", "Snack", "Canned", "Frozen", "Dairy", "Meat"};

    void Start()
    {
        panel = GameObject.Find("MapMenu");
        panel.SetActive(false);

        shoppingCartPanel = GameObject.Find("Cart_Panel");
        shoppingCartPanel.SetActive(false);
        Debug.Log("Shopping cart closeeeee");

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        player = GameObject.FindGameObjectWithTag("Player");
        shoppingList = GameObject.Find("ShoppingList");
        dialogueHandler = GameObject.Find("NPCAlertTest").GetComponent<DialogueHandler>();
        shoppingList.SetActive(false);
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
    }
    public void OpenPanel()
    {
        
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
            shoppingCartPanel.SetActive(false);
        }
    }
    public void ToggleCartPanel()
    {
        if (shoppingCartPanel != null)
        {
            bool cartActive = shoppingCartPanel.activeSelf;
            shoppingCartPanel.SetActive(!cartActive);
            panel.SetActive(false);
        }
        InventoryManager.Instance.ShowItem();
    }

    public void CheckOut()
    {
        SceneManager.LoadScene("CashRegister");
    }

    public void TeleportToAisleDynamic()
    {
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