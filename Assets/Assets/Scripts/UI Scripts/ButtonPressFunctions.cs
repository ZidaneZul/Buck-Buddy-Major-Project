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
        SceneManager.LoadScene("PlayerSelect");
    }
    public void SelectLvl()
    {
        SceneManager.LoadScene("LevelSelectTest");
    }

    public void Back()
    {
        SceneManager.LoadScene("LevelSelectTest");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + (buttonDataHolder.LevelSelected + 1));
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("Level" + (buttonDataHolder.LevelSelected));
    }


}
