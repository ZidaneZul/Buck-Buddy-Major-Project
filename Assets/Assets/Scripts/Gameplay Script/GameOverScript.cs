using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Objective objectiveData;
    public float levelBudget;
    public GameObject gameOverMenu;


    private void Start()
    {
        objectiveData = GameObject.Find("GameManager").GetComponent<Objective>();
        levelBudget = objectiveData.GetBudget();
        gameOverMenu.SetActive(false);
    }

    private void Update()
    {
        if (levelBudget <= 0)
        {
            gameOverMenu.SetActive(true);
        }
        else
        {
            gameOverMenu.SetActive(false);
        }
    }

    public void SelectNewLevel()
    {
        SceneManager.LoadScene("LevelSelectTest");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }
}
