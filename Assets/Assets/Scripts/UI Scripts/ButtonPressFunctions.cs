using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonPressFunctions : MonoBehaviour
{
    public ButtonDataHolder buttonDataHolder;
    public GameObject uiAudio;

    void Start()
    {
        buttonDataHolder = GameObject.Find("RandomEventHandler").GetComponent<ButtonDataHolder>();

    }
    // Update is called once per frame
    public void ConfirmSelection()
    {
        SceneManager.LoadScene("Level" + buttonDataHolder.LevelSelected);
        Destroy(uiAudio, 0.5f);
        Destroy(GameObject.Find("BGM"));
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelect");
        Destroy(uiAudio, 0.5f);
    }
    public void SelectLvl()
    {
        SceneManager.LoadScene("LevelSelectTest");
        Destroy(uiAudio, 0.5f);
    }

    public void Back()
    {
        SceneManager.LoadScene("LevelSelectTest");
        Destroy(uiAudio, 0.5f);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + (buttonDataHolder.LevelSelected + 1));
        Destroy(uiAudio, 0.5f);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(uiAudio, 0.5f);
        Destroy(GameObject.Find("BGM"));
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("Level" + (buttonDataHolder.LevelSelected));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
