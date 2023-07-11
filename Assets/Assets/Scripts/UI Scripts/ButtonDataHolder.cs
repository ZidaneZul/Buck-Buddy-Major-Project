using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ButtonDataHolder : MonoBehaviour
{
    public int LevelSelected;
    public Scene scene;
    public TextMeshProUGUI textMeshProUGUI;


    private void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "LevelConfirm")
        {
           textMeshProUGUI = GameObject.Find("LevelNumber").GetComponent<TextMeshProUGUI>();
           textMeshProUGUI.text = "Level " + LevelSelected;
        }
    }

}
