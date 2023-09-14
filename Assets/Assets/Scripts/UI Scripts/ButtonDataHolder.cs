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
    public Image star1, star2, star3;
    public Sprite[] starImages;


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

        if(stopper == false && scene.name == "LevelConfirm")
        {
           levelNumberHolder = GameObject.Find("LevelNumber").GetComponent<TextMeshProUGUI>();
           recipeName = GameObject.Find("LevelRecipe").GetComponent<TextMeshProUGUI>();
           ingredientText = GameObject.Find("ObjectiveInformation").GetComponent<TextMeshProUGUI>();
           levelRecipe = GameObject.Find("LevelRecipeIcon").GetComponent<Image>();
           levelNumberHolder.text = "Level " + LevelSelected;
           star1 = GameObject.Find("StarMainMenu1").GetComponent<Image>();
           star2 = GameObject.Find("StarMainMenu2").GetComponent<Image>();
           star3 = GameObject.Find("StarMainMenu3").GetComponent<Image>();


            foreach (LevelData.LevelDataHolder data in levelData.levelDataHolder)
            {
                if(data.levelNumber == LevelSelected)
                {
                    recipeName.text = data.foodName;
                    levelRecipe.sprite = data.itemToMake;
                    for (int i = 0; i < data.ingredients.Length; i++)
                    {
                        if(i == 0)
                        {
                            ingredientText.text += data.ingredients[i];
                      
                        }

                        else
                        {
                            ingredientText.text += " | " + data.ingredients[i];

                        }
                    }
                    stopper = true;
                    switch (data.levelStarAmount)
                    {
                        case 0:
                            {
                                star1.sprite = starImages[0];
                                star2.sprite = starImages[0];
                                star3.sprite = starImages[0];
                                break;
                            }
                        case 1:
                            {
                                star1.sprite = starImages[1];
                                star2.sprite = starImages[0];
                                star3.sprite = starImages[0];
                                break;
                            }
                        case 2:
                            {
                                star1.sprite = starImages[1];
                                star2.sprite = starImages[1];
                                star3.sprite = starImages[0];
                                break;
                            }
                        case 3:
                            {
                                star1.sprite = starImages[1];
                                star2.sprite = starImages[1];
                                star3.sprite = starImages[1];
                                break;
                            }

                    }

                }
            }

        }
    }

}
