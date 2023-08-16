using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdjecentAisleScript : MonoBehaviour
{
    public GameObject go, leftObject, rightObject, currentObject;
    public TextMeshProUGUI currentAisle, leftAisle, rightAisle;

    public GameObject[] aisles;

    public List<KeyValuePair<string, Sprite>> aisleIcons = new List<KeyValuePair<string, Sprite>>();    
    // Start is called before the first frame update
    void Start()
    {
        aisles = GameObject.FindGameObjectsWithTag("Sections");
        go = GameObject.Find("AdjecentAisles");

        currentObject = go.transform.GetChild(1).gameObject;
        leftObject = go.transform.GetChild(2).gameObject;
        rightObject = go.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}