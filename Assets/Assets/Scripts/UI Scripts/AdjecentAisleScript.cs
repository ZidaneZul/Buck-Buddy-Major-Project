using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdjecentAisleScript : MonoBehaviour
{
    public GameObject go, leftObject, rightObject, currentObject;
    public TextMeshProUGUI currentAisle_txt, leftAisle_txt, rightAisle_txt;

    public GameObject[] aisles;
    public GameObject[] aislesClone;

    public MapLocation mapLocationScript;

    public List<KeyValuePair<string, Sprite>> aisleIcons = new List<KeyValuePair<string, Sprite>>();
    // Start is called before the first frame update
    void Start()
    {
        aisles = GameObject.FindGameObjectsWithTag("Sections");
        go = GameObject.Find("AdjecentAisles");

        currentObject = go.transform.GetChild(1).gameObject;
        currentAisle_txt = currentObject.GetComponentInChildren<TextMeshProUGUI>();

        leftObject = go.transform.GetChild(2).gameObject;
        leftAisle_txt = leftObject.GetComponentInChildren<TextMeshProUGUI>();

        rightObject = go.transform.GetChild(3).gameObject;
        rightAisle_txt = rightObject.GetComponentInChildren<TextMeshProUGUI>();


        mapLocationScript = GameObject.Find("GameManager").GetComponent<MapLocation>();

    }

    // Update is called once per frame
    void Update()
    {
        DisplayCurrentAisle();

        DisplayRightSide();
        DisplayLeftSide();
    }

    void DisplayCurrentAisle()
    {
        currentAisle_txt.text = mapLocationScript.FindPlayer();
    }
    void DisplayLeftSide()
    {
        leftAisle_txt.text = mapLocationScript.FindLeftAdjecentAisle();
    }

    void DisplayRightSide()
    {
        rightAisle_txt.text = mapLocationScript.FindRightAdjecentAisle();
    }
}