using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCRandomChance : MonoBehaviour
{
    Scene currentScene;
    string SceneName;

    
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;  
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    IEnumerator NPCMaker(string NPCtoSpawn)
    {
        if (NPCtoSpawn == "Level1")
        {
            Debug.Log("A random NPC Appears");
            yield return new WaitForSeconds(3f);
            StopAllCoroutines();
        }
    }
}
