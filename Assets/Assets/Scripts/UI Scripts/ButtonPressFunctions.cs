using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonPressFunctions : MonoBehaviour
{
    public ButtonDataHolder buttonDataHolder;

    void Start()
    {
        buttonDataHolder = GameObject.Find("RandomEventHandler").GetComponent<ButtonDataHolder>();

    }
    // Update is called once per frame
    public void ConfirmSelection()
    {
        SceneManager.LoadScene("Level" + buttonDataHolder.LevelSelected);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Back()
    {
        SceneManager.LoadScene("LevelSelect");
    }



}
