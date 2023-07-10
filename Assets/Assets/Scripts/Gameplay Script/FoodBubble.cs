using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodBubble : MonoBehaviour
{

    public GameObject infoBubble;
    private GameObject player, bubbleClone;
    TextMeshPro TMP;
    Sprite sprite;

    bool hasSpawned = false;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        ShowBubble();
    }

    
    void ShowBubble()
    {
        if (IsPlayerClose() && hasSpawned)
        {
            bubbleClone = Instantiate(infoBubble);
            TMP = bubbleClone.GetComponentInChildren<TextMeshPro>();
            sprite = bubbleClone.GetComponentInChildren<Sprite>();
            hasSpawned = true;
        }
        else
        {
            Destroy(bubbleClone);
            hasSpawned=false;
        }
    }



    bool IsPlayerClose()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            return true;
        }
        else return false;
    }

    void ChangeText(string item)
    {
        if(item == "fish")
        {
            TMP.text = "Fish" + "\n" + "$5";
        }

    }

}
