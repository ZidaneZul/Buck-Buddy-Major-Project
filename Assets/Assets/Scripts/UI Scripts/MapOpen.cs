using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapOpen : MonoBehaviour
{
    public GameObject panel, player, buttonPressed;
    public GameObject[] waypoints;
    

    string waypointString, buttonName;
    string[] aisles = { "Bread", "Drink" };

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        panel = GameObject.Find("MapMenu");
        panel.SetActive(false);
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
    private void Update()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypointString = waypoints[i].ToString();
            if (waypointString.Contains("Bread"))   {Debug.Log("bread time");}
            else if (waypointString.Contains("Drink")) { Debug.Log("Drunk"); }
            else if (waypointString.Contains("bread")) { Debug.Log("Bread but shorter"); }
                
        }
    }
    public void OpenPanel()
    {
        
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }

    public void TeleportToAisleDynamic()
    {
        buttonPressed = EventSystem.current.currentSelectedGameObject;
        buttonName = buttonPressed.ToString();


        Debug.Log("Button name" + buttonName);

        foreach (string aisle in aisles)
        {
            Debug.Log("Checking for keywords");
            if (buttonName.Contains(aisle))
            {
                Debug.Log("The button contains keyword" + aisle);
                for (int i = 0; i < waypoints.Length; i++)
                {
                    waypointString = waypoints[i].ToString();
                    if (waypointString.Contains(aisle))
                    {
                        player.transform.position = waypoints[i].transform.position;
                        panel.SetActive(false);
                    }
                }
            }
        }

    }
}




