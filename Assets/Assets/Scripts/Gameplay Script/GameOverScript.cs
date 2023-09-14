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
            if (scoreBoard != null && scoreBoard.activeInHierarchy)
            {
                float currentTime = (timeData.mainLevelTime + timeData.cashierTime);
                float minutes = Mathf.FloorToInt(currentTime / 60);
                float seconds = Mathf.FloorToInt(currentTime % 60);
                timeReport.text = "Time Taken: " + string.Format("{0:00}m {1:00}s", minutes, seconds); ;
                return;
            }
            else
            {
                timeStart += Time.deltaTime;
                Timer(timeStart);
                timeData.cashierTime = timeStart;
            }

            

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
