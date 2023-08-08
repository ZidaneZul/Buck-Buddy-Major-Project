using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public GameObject GrayedBox,MapBtn,CartBtn,MovementBtn,TutorialChatBox;
    public TextMeshProUGUI TutorialMesssage;


    // Start is called before the first frame update
    void Start()
    {
        GrayedBox = GameObject.Find("TutorialBox");
        MapBtn = GameObject.Find("TutorialMap");
        CartBtn = GameObject.Find("TutorialCart");
        MovementBtn = GameObject.Find("TutorialMovementArrows");
        TutorialChatBox = GameObject.Find("TutorialMessage");
        TutorialMesssage = TutorialChatBox.GetComponent<TextMeshProUGUI>();

        GrayedBox.SetActive(false);
        MapBtn.SetActive(false);
        CartBtn.SetActive(false);
        MovementBtn.SetActive(false);
        TutorialChatBox.SetActive(false);
        




        if (SceneManager.GetActiveScene().name == "Level1")
        {
            StartCoroutine(StartTutorial());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartTutorial()
    {
        GrayedBox.SetActive(true);
        TutorialChatBox.SetActive(true);
        TutorialMesssage.text = "Tutorial Message 1 plays";
        yield return new WaitForSeconds(2f);
        CartBtn.SetActive(true);
        TutorialMesssage.text = "Explaining Cart Feature";
        yield return new WaitForSeconds(4f);
        CartBtn.SetActive(false);
        MapBtn.SetActive(true);
        TutorialMesssage.text = "Explaining Map Features";
        yield return new WaitForSeconds(4f);
        MapBtn.SetActive(false);
        MovementBtn.SetActive(true);
        TutorialMesssage.text = "Explaining how to move";
        yield return new WaitForSeconds(4f);
        MovementBtn.SetActive(false);
        TutorialMesssage.text = "Bye bye";
        yield return new WaitForSeconds(4f);
        GrayedBox.SetActive(false);
        StopAllCoroutines();
    }
}
