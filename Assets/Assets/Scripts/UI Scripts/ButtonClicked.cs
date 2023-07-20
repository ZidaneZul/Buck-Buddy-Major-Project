using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public ButtonDataHolder buttonDataHolder;
    void Start()
    {
        buttonDataHolder = GameObject.Find("RandomEventHandler").GetComponent<ButtonDataHolder>();
    }
    // Start is called before the first frame update
    public void WhichBtnClicked(Button btn)
    {
        btn.transform.name = "clicked";
        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {

                buttonDataHolder.LevelSelected = i + 1;
                SceneManager.LoadScene("LevelConfirm");

            }
        }

    }
}
