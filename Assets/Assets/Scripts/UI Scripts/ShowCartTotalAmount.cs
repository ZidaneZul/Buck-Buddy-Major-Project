using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowCartTotalAmount : MonoBehaviour
{
    int State;

    Image image;

    TextMeshProUGUI totalAmtTMP;

    float totalAmount;

    [SerializeField]
    private Sprite[] switchSprites;

    // Start is called before the first frame update
    void Start()
    {
        totalAmtTMP = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        totalAmount = InventoryManager.Instance.totalPrice;

        //needed here and not in the func so that the total price would update after removing item

        if(State == 0)
        {
            totalAmtTMP.text = "Total: \n -------";
        }
        else
        {
            totalAmtTMP.text = "Total: \n $" + totalAmount.ToString("F2");

        }
    }

    public void ShowOrHideTotal()
    {
        State = 1 - State;
        image.sprite = switchSprites[State]; 
    }
}
