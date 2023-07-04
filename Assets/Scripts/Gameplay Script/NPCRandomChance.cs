using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCRandomChance : MonoBehaviour
{
    Scene currentScene;
    string SceneName;
    NPCRandomChance randomChance;
    public GameObject[] NPC;

    // To preload variables that will stay between transition of scenes

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(randomChance == null)
        {
            randomChance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;  
        StartCoroutine(NPCMaker(SceneName));    
    
    }

    void Update()
    {
        SceneChanged();
        TemporaryButton();
    }

    IEnumerator NPCMaker(string NPCtoSpawn)
    {
        if(NPCtoSpawn == "SampleScene")
        {
            SceneManager.LoadScene("Level1");
        }
        if (NPCtoSpawn == "Level1")
        {
            int randomNPC = Random.Range(0, NPC.Length);
            Debug.Log("A random NPC Appears");
            Instantiate(NPC[randomNPC]);
            yield return new WaitForSeconds(3f);
            StopCoroutine(NPCMaker(NPCtoSpawn));
        }
    }
    

    void SceneChanged()
    {
        if(SceneManager.GetActiveScene() != currentScene)
        {
            currentScene = SceneManager.GetActiveScene();
            SceneName = currentScene.name;
            StartCoroutine(NPCMaker(SceneName));
        }

    }

    void TemporaryButton()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("Level2");
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");

        }
    }
}
