using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public Objective objectiveData;
    public float levelBudget;
    public GameObject gameOverMenu;
    public float timeStart;
    public TextMeshProUGUI timerText;


    private void Start()
    {
        objectiveData = GameObject.Find("GameManager").GetComponent<Objective>();
        levelBudget = objectiveData.GetBudget();
        gameOverMenu.SetActive(false);
        timeStart = 0;
    }

    private void Update()
    {

        timeStart += Time.deltaTime;
        Timer(timeStart);

        if (levelBudget <= 0)
        {
            GameOver(true);
            return; 
        }
        else
        {
            GameOver(false);
            return;
        }
    }
    public void Timer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        
    }

    public void GameOver(bool lost)
    {
        gameOverMenu.SetActive(lost);
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
