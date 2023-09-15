using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectCharacterScript : MonoBehaviour
{
    public GameObject uiAudio;
    public bool IsMale;

    Color dim, bright;
    // 3C3C3C dim

    public Button maleButton, femaleButton, ctnBtn;

    public PlayerSelectOption playerSelectScript;
    // Start is called before the first frame update
    void Start()
    {
        maleButton = GameObject.Find("MaleSelect_Btn").GetComponent<Button>();
        femaleButton = GameObject.Find("FemaleSelect_Btn").GetComponent<Button>();
        ctnBtn = GameObject.Find("Continue_Btn").GetComponent<Button>();
        playerSelectScript = GameObject.Find("RandomEventHandler").GetComponent<PlayerSelectOption>();

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
        playerSelectScript.isMale = true;
        maleButton.GetComponent<Image>().color = bright;
        femaleButton.GetComponent<Image>().color = dim;
        ctnBtn.GetComponent<Image>().color = Color.green;
    }

    public void SelectFemale()
    {
        IsMale=false;
        playerSelectScript.isMale = false;
        maleButton.GetComponent <Image>().color = dim;
        femaleButton.GetComponent <Image>().color = bright;
        ctnBtn.GetComponent<Image>().color = Color.green;
    }

    public void Continue()
    {
        if(ctnBtn.GetComponent<Image>().color == Color.green)
        {
            Debug.Log("Go Next");
            Debug.Log("is male is " + IsMale);
            SceneManager.LoadScene("LevelSelectTest");
        }
        Destroy(uiAudio, 0.5f);
    }
}
