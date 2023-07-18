using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapOpen : MonoBehaviour
{
    public GameObject panel, player, buttonPressed, shoppingCartPanel;
    public GameObject[] waypoints;
    

    string waypointString, buttonName;
    string[] aisles = { "Bread", "Drink" };

    void Start()
    {
        panel = GameObject.Find("MapMenu");
        panel.SetActive(false);

        shoppingCartPanel = GameObject.Find("Cart_Panel");
        shoppingCartPanel.SetActive(false);
        // Debug.Log("Shopping cart closeeeee");

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        //for (int i = 0; i < waypoints.Length; i++)
        //{
        //    waypointString = waypoints[i].ToString();
        //    if (waypointString.Contains("Bread"))   {Debug.Log("bread time");}
        //    else if (waypointString.Contains("Drink")) { Debug.Log("Drunk"); }
        //    else if (waypointString.Contains("bread")) { Debug.Log("Bread but shorter"); }  
        //}
    }
    public void OpenPanel()
    {
        
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }
    public void ToggleCartPanel()
    {
        Debug.Log("HEEEEEEEEEELP" + shoppingCartPanel);
        if (shoppingCartPanel != null)
        {
            bool cartActive = shoppingCartPanel.activeSelf;
            shoppingCartPanel.SetActive(!cartActive);
        }
        InventoryManager.Instance.ShowItem();
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