using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class NPCRandomChance : MonoBehaviour
{
    Scene currentScene;
    string SceneName;
    NPCRandomChance randomChance;
    public GameObject[] NPC;
    public GameObject[] SpawnPoints;
    public NavMeshAgent nma;
    public GameObject Player;
    public int SpawnPointLocation = 0;
    public bool patrol;


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
        SpawnPoints = GameObject.FindGameObjectsWithTag("Spawners");
        StartCoroutine(NPCSpawner(SceneName));
        GotoNextPoint();



    }

    void Update()
    {

        GotoNextPoint();
        SceneChanged();
        TemporaryButton();
        Debug.Log(Vector3.Distance(nma.transform.position, nma.destination));

    }

    IEnumerator NPCSpawner(string NPCtoSpawn)
    {
        if(NPCtoSpawn == "SampleScene")
        {
            SceneManager.LoadScene("Level1");
        }
        if (NPCtoSpawn == "Level1")
        {
            int randomNPC = Random.Range(0, NPC.Length);
            SpawnPointLocation = Random.Range(0, SpawnPoints.Length);

            Debug.Log("A random NPC Appears");
            Instantiate(NPC[randomNPC],SpawnPoints[SpawnPointLocation].transform);
            nma = GameObject.FindGameObjectWithTag("NPC").GetComponent<NavMeshAgent>();
            nma.stoppingDistance = 0.25f;
            yield return new WaitForSeconds(3f);
            StopAllCoroutines();

        }
    }


    void GotoNextPoint()
    {
        if (Player == null)
        {
            if (GameObject.FindGameObjectWithTag("NPC"))
            {
                if ((SpawnPointLocation == 0) && patrol == false)
                {
                    patrol = true;
                    if (nma.destination == null)
                    {
                        nma.SetDestination(SpawnPoints[SpawnPointLocation + 1].transform.position);

                    }

                    else if (Vector3.Distance(nma.transform.position, nma.destination) < 0.25f)
                    {
                        Debug.Log("Made it");
                        nma.SetDestination(SpawnPoints[SpawnPointLocation].transform.position);
                        Vector3 newPosition = SpawnPoints[SpawnPointLocation].transform.position;
                        if (Vector3.Distance(nma.transform.position, newPosition) < 0.25f)
                        {
                            nma.ResetPath();
                            patrol = false;
                        }
                        else
                        {
                            return;
                        }

                    }

                }

                if ((SpawnPointLocation % 2 == 0) && patrol == false)
                {
                    patrol = true;
                    if(nma.destination == null)
                    {
                        nma.SetDestination(SpawnPoints[SpawnPointLocation + 1].transform.position);

                    }

                    else if (Vector3.Distance(nma.transform.position, nma.destination) < 0.25f)
                    {
  

                        nma.SetDestination(SpawnPoints[SpawnPointLocation].transform.position);
                        Vector3 newPosition = SpawnPoints[SpawnPointLocation].transform.position;
                        if (Vector3.Distance(nma.transform.position, newPosition) < 0.25f)
                        {
                            nma.ResetPath();
                            patrol = false;
                        }

                        else
                        {
                            return;
                        }
                    }


                }

                if ((SpawnPointLocation % 2 == 1) && patrol == false)
                {
                    patrol = true;
                    if(nma.destination == null)
                    {
                        nma.SetDestination(SpawnPoints[SpawnPointLocation - 1].transform.position);


                    }
                    else if (Vector3.Distance(nma.transform.position, nma.destination) < 0.25f)
                    {
                        Debug.Log("Made it");
                        nma.SetDestination(SpawnPoints[SpawnPointLocation].transform.position);
                        Vector3 newPosition = SpawnPoints[SpawnPointLocation].transform.position;
                        Debug.Log(nma.destination);
                        if (Vector3.Distance(nma.transform.position, newPosition) < 0.25f)
                        {
                            nma.ResetPath();
                            patrol = false;
                        }


                        else
                        {
                            return;
                        }
                    }

                }

            }
        }

    }

    

    void SceneChanged()
    {
        if(SceneManager.GetActiveScene() != currentScene)
        {
            currentScene = SceneManager.GetActiveScene();
            SceneName = currentScene.name;
            SpawnPoints = GameObject.FindGameObjectsWithTag("Spawners");
            StartCoroutine(NPCSpawner(SceneName));
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
