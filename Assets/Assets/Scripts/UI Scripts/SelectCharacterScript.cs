using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterScript : MonoBehaviour
{
    bool IsMale, isFemale;

    Color dim, bright;
    // 3C3C3C dim

    public Button maleButton, femaleButton;
    // Start is called before the first frame update
    void Start()
    {
        maleButton = GameObject.Find("MaleSelect_Btn").GetComponent<Button>();
        femaleButton = GameObject.Find("FemaleSelect_Btn").GetComponent<Button>();

        dim = new Color(0.25f, 0.25f, 0.25f, 1f);
        bright = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectMale()
    {
        IsMale = true;
        maleButton.GetComponent<Image>().color = bright;
        femaleButton.GetComponent<Image>().color = dim;
    }

    public void SelectFemale()
    {
        IsMale=false;
    }
}
