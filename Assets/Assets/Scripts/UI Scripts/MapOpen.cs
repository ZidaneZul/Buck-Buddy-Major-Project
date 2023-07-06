using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpen : MonoBehaviour
{
    public GameObject Panel;
    public GameObject[] Waypoints;

    void Start()
    {
        Panel.SetActive(false);
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
    private void Update()
    {
        Debug.Log(Waypoints.ToString());
    }
    public void OpenPanel()
    {
        
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }

    public void TeleportTo()
    {

    }
}




