using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsChecker : MonoBehaviour
{
    public PaymentDrop paymentDrop;

    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;

    // Start is called before the first frame update
    void Start()
    {
        oneStar.SetActive(false);
        twoStar.SetActive(false);
        threeStar.SetActive(false);
    }

    public void Checker()
    {
        if (paymentDrop.amountAdded==paymentDrop.randomNumber )
        {
            threeStar.SetActive(true);
            twoStar.SetActive(false);
            threeStar.SetActive(false);
        }
        else if(paymentDrop.amountAdded - paymentDrop.randomNumber < 3f)
        {
            threeStar.SetActive(false);
            twoStar.SetActive(true);
            threeStar.SetActive(false);
        }
        else if (paymentDrop.amountAdded - paymentDrop.randomNumber < 6f)
        {
            threeStar.SetActive(false);
            twoStar.SetActive(false);
            threeStar.SetActive(true);
        }
        else
        {
            oneStar.SetActive(false);
            twoStar.SetActive(false);
            threeStar.SetActive(false);
        }
    }
}
