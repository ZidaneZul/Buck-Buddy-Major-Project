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
    public TextMeshProUGUI levelNumberHolder, recipeName, ingredientText;
    public Image levelRecipe;
    public LevelData levelData;
    public bool stopper;


    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene();

        if(scene.name == "PreloadScene")
        {
            SceneManager.LoadScene("MainMenu");
        }
        if(scene.name == "LevelSelectTest")
        {
            stopper = false;    
        }

        if (scene.name == "LevelConfirm")
        {
           levelNumberHolder = GameObject.Find("LevelNumber").GetComponent<TextMeshProUGUI>();
           recipeName = GameObject.Find("LevelRecipe").GetComponent<TextMeshProUGUI>();
           ingredientText = GameObject.Find("ObjectiveInformation").GetComponent<TextMeshProUGUI>();
           levelRecipe = GameObject.Find("LevelRecipeIcon").GetComponent<Image>();
           levelNumberHolder.text = "Level " + LevelSelected;
            foreach (LevelData.LevelDataHolder data in levelData.levelDataHolder)
            {
                if(data.levelNumber == LevelSelected)
                {
                    recipeName.text = data.foodName;
                    levelRecipe.sprite = data.itemToMake;

                }
            }

        }
    }

}
