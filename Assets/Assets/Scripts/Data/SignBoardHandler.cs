using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SignBoardHandler : MonoBehaviour
{
    public SignBoardData signBoardData;
    public Transform item1Holder;
    public TextMeshPro item1Text;
    public Transform item2Holder;
    public TextMeshPro item2Text;
    public Transform item3Holder;
    public TextMeshPro item3Text;
    public Transform pictureHolder;
    public SpriteRenderer pictureImage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        item1Holder = gameObject.transform.Find("Item1");
        item1Text = item1Holder.GetComponent<TextMeshPro>();
        item2Holder = gameObject.transform.Find("Item2");
        item2Text = item2Holder.GetComponent<TextMeshPro>();
        item3Holder = gameObject.transform.Find("Item3");
        item3Text = item3Holder.GetComponent<TextMeshPro>();
        pictureHolder = gameObject.transform.Find("Picture");
        pictureImage = pictureHolder.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        item1Text.text = signBoardData.itemName1;
        item2Text.text = signBoardData.itemName2;
        item3Text.text = signBoardData.itemName3;
        pictureImage.sprite = signBoardData.Icon;
        
    }
}
