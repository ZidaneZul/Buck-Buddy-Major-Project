using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverScript : MonoBehaviour
{
    public GameObject uiAudio;
    public Objective objectiveData;
    public float levelBudget;
    public GameObject gameOverMenu;
    public float timeStart;
    public TextMeshProUGUI timerText;
    public TimeData timeData;
    public GameObject scoreBoard;
    public TextMeshProUGUI timeReport;
    public LevelData levelData;

    private void Start()
    {
        objectiveData = GameObject.Find("GameManager").GetComponent<Objective>();
        levelBudget = objectiveData.GetBudget();
        gameOverMenu.SetActive(false);
        timeStart = 0;
    }

    private void Update()
    {


        // If the scene is not cash register, the time taken will modify the dataset for the main level section
        // The game will continuously count up and it will check the level budget to ensure it is always above 0, if it below 0 it will result in a game over
        if(SceneManager.GetActiveScene().name != "CashRegister")
        {
            timeStart += Time.deltaTime;
            Timer(timeStart);
            timeData.mainLevelTime = timeStart;
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
        //if (scoreBoard != null && scoreBoard != isActiveAndEnabled)
        //{
        //    timeStart += Time.deltaTime;
        //    Timer(timeStart);
        //    timeData.cashierTime = timeStart;
        //}
        else
        {
            if (scoreBoard != null && scoreBoard.activeInHierarchy) // If the end game score board is not empty and is active, it will display the total time taken
            {
                float currentTime = (timeData.mainLevelTime + timeData.cashierTime);
                float minutes = Mathf.FloorToInt(currentTime / 60);
                float seconds = Mathf.FloorToInt(currentTime % 60);
                timeReport.text = "Time Taken: " + string.Format("{0:00}m {1:00}s", minutes, seconds); ;
                return;
            }
            else
            {
                timeStart += Time.deltaTime; //  if the score isnt active then it will signify that it is in the cashier scene, any time taken will modify the time taken value in cashiertime
                Timer(timeStart);
                timeData.cashierTime = timeStart;
            }

            

        }

    }
    public void Timer(float currentTime) // Timer to display on the hud in a clock format
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
        Destroy(uiAudio, 0.5f);
        Destroy(GameObject.Find("BGM"));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(uiAudio, 0.5f);
        Destroy(GameObject.Find("BGM"));
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
        Destroy(uiAudio, 0.5f);
    }


}
