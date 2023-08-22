using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject settingBtn;
    GameObject menuPanel;
    GameObject confirmBtn, declineBtn;
    TextMeshProUGUI menuTxt;
    bool menuActive;


    private void Start()
    {
        
        settingBtn = GameObject.Find("SettingButton");
        menuPanel = GameObject.Find("GrayedBackgroundMenu");
        confirmBtn = GameObject.Find("ConfirmBtn");
        declineBtn = GameObject.Find("DeclineBtn");
        menuTxt = GameObject.Find("MenuTxt").GetComponent<TextMeshProUGUI>();

        menuPanel.SetActive(false);
        confirmBtn.SetActive(false);
        declineBtn.SetActive(false);



    }

    public void MenuButtonClicked()
    {
        menuActive = !menuActive;
        menuPanel.SetActive(menuActive);
        confirmBtn.SetActive(false);
        declineBtn.SetActive(false);
    }

    public void ConfirmationPage()
    {
        menuTxt.text = "CONFIRM?";
        confirmBtn.SetActive(true);
        declineBtn.SetActive(true);
    }

    public void Decline()
    {
        menuTxt.text = "PAUSED";
        confirmBtn.SetActive(false);
        declineBtn.SetActive(false);
    }

    public void Confirmed()
    {
        SceneManager.LoadScene("MainMenu");
    }





}
