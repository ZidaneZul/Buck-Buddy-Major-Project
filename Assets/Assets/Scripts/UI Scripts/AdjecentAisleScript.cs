using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AdjecentAisleScript : MonoBehaviour
{
    public GameObject go, leftObject, rightObject, currentObject;
    public TextMeshProUGUI currentAisle_txt, leftAisle_txt, rightAisle_txt;
    public Image currentAisle_img, leftAisle_img, rightAisle_img;

    public Image[] uiAislesImages;

    public MapLocation mapLocationScript;

    public MatchAisleIcons[] aisleIconsList;

    public string[] aisleOrder;
    public List<string> aisleNames;

    [System.Serializable]
    public class MatchAisleIcons
    {
        public Sprite icon;
        public string ailse;
    }

    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("AdjecentAisles");

        currentObject = go.transform.GetChild(1).gameObject;
        currentAisle_txt = currentObject.GetComponentInChildren<TextMeshProUGUI>();
        currentAisle_img = currentObject.GetComponentInChildren<Image>();

        leftObject = go.transform.GetChild(2).gameObject;
        leftAisle_txt = leftObject.GetComponentInChildren<TextMeshProUGUI>();
        leftAisle_img = leftObject.GetComponentInChildren<Image>();

        rightObject = go.transform.GetChild(3).gameObject;
        rightAisle_txt = rightObject.GetComponentInChildren<TextMeshProUGUI>();
        rightAisle_img = rightObject.GetComponentInChildren<Image>();

        mapLocationScript = GameObject.Find("GameManager").GetComponent<MapLocation>();

        SetAislesIcons();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mapLocationScript);
        //SetAislesIcons();
        //DisplayCurrentAisle();

        //DisplayRightSide();
        //DisplayLeftSide();
    }

    void SetAislesIcons()
    {
        string aisleorder_string = "";
        aisleNames= mapLocationScript.GetAislesOrder();

        foreach(string aisle in aisleNames)
        {
            aisleorder_string += aisle;
        }

        Debug.LogWarning("aisle order is " + aisleorder_string);
        

      
    }

    void DisplayCurrentAisle()
    {
        currentAisle_txt.text = mapLocationScript.FindPlayer();

        foreach(var aisleIcon in aisleIconsList)
        {
            if (currentAisle_txt.text.Contains(aisleIcon.ailse))
            {
                currentAisle_img.sprite = aisleIcon.icon;
            }
        }
    }
    void DisplayLeftSide()
    {
        leftAisle_txt.text = mapLocationScript.FindLeftAdjecentAisle();
        if (leftAisle_txt.text == null)
        {
            leftAisle_img.enabled = false;
            Debug.Log("Hiding image" + leftAisle_img.enabled);
        }
        else
        {
            leftAisle_img.enabled = true;
            foreach (var aisleIcon in aisleIconsList)
            {
                if (leftAisle_txt.text.Contains(aisleIcon.ailse))
                {
                    leftAisle_img.sprite = aisleIcon.icon;
                    break;
                }
            }
        }
    }

    void DisplayRightSide()
    {
        rightAisle_txt.text = mapLocationScript.FindRightAdjecentAisle();
        if (rightAisle_txt.text == null)
        {
            rightAisle_img.enabled = false;
        }
        else
        {
            rightAisle_img.enabled = true;

            foreach (var aisleIcon in aisleIconsList)
            {
                if (rightAisle_txt.text.Contains(aisleIcon.ailse))
                {
                    rightAisle_img.sprite = aisleIcon.icon;
                    break;
                }
            }
        }
    }
}