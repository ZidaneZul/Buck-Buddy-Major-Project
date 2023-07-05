using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpen : MonoBehaviour
{
    public GameObject Panel;

    void Start()
    {
        Panel.SetActive(false);
    }

    public void OpenPanel()
    {
        
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}




