using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpen : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        Panel.SetActive(false);
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(true);
        }
    }
}




