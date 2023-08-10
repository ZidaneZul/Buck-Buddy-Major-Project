using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectOption : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isMale;

    public SelectCharacterScript selectCharScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMale);
    }

    public void GetGenderOption()
    {
        selectCharScript = GameObject.Find("Canvas").GetComponent<SelectCharacterScript>();
        isMale = selectCharScript.IsMale;
        Debug.Log("isMale from dont destroy is "+ isMale + "\n ismale from Selecting char is " +selectCharScript.IsMale); ;
        Debug.Log("Stealing information");
    }
}
