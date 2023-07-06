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
    public Transform target;
    public CharacterScript character;
    public Collider[] collidedObjects;
    public bool interacted;

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



    }

    void Update()
    {

        GotoNextPoint();
        SceneChanged();
        TemporaryButton();

    }
    void FixedUpdate()
    {

        if (GameObject.FindGameObjectWithTag("NPC"))
        {
            collidedObjects = Physics.OverlapSphere(nma.transform.position, 3f);
        }

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
    bool PlayerDetection()
    {
        float distance = 5f;
        foreach (Collider k in collidedObjects)
        {
            if (k.gameObject.tag == "Player")
            {
                Player = k.gameObject;
                character = k.gameObject.GetComponent<CharacterScript>();
                return true;
            }
        }
        return false;
    }


    void GotoNextPoint()
    {
        if (!PlayerDetection())
        {
            if (GameObject.FindGameObjectWithTag("NPC"))
            {
                if (SpawnPointLocation == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (target == null)
                        {

                            target = SpawnPoints[SpawnPointLocation + i].transform;

                        }
                        nma.stoppingDistance = 0f;

                        if (nma.destination != nma.transform.position)
                        {
                            nma.SetDestination(target.position);
                        }

                        if (!nma.pathPending && nma.remainingDistance <= nma.stoppingDistance)
                        {
                            target = null;
                        }
                    }


                }

                if (SpawnPointLocation % 2 == 0)
                {

                    for (int i = 0; i < 2; i++)
                    {
                        if (target == null)
                        {

                            target = SpawnPoints[SpawnPointLocation + i].transform;

                        }
                        nma.stoppingDistance = 0f;

                        if (nma.destination != nma.transform.position)
                        {
                            nma.SetDestination(target.position);
                        }

                        if (!nma.pathPending && nma.remainingDistance <= nma.stoppingDistance)
                        {
                            target = null;

                        }
                    }


                }

                if (SpawnPointLocation % 2 == 1)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (target == null)
                        {

                            target = SpawnPoints[SpawnPointLocation - i].transform;

                        }

                        nma.stoppingDistance = 0f;


                        if (nma.destination != nma.transform.position)
                        {
                            nma.SetDestination(target.position);
                        }

                        if (!nma.pathPending && nma.remainingDistance <= nma.stoppingDistance)
                        {
                            target = null;
                        }
                    }



                }

            }
        }
        else if ((PlayerDetection()) && (interacted == false))
        {
            nma.isStopped = true;
            character.speed = 0f;
            Transform characterDirection = character.transform;

            if (nma.transform.position.x < character.transform.position.x)
            {
                Vector3 localScaleCharacter = transform.localScale;
                Vector3 localScaleNMA = transform.localScale;
                localScaleCharacter.x *= -1f;
                localScaleNMA.x *= 1f;
                nma.transform.localScale = new Vector3(localScaleNMA.x,nma.transform.localScale.y,nma.transform.localScale.z);
                character.transform.localScale = new Vector3(localScaleCharacter.x, character.transform.localScale.y, character.transform.localScale.z);
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    interacted = true;
                    nma.isStopped = false;
                    character.transform.localScale = characterDirection.transform.localScale;
                    character.speed = 3f;
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    interacted = true;
                    character.transform.localScale = characterDirection.transform.localScale;
                    nma.gameObject.SetActive(false);
                    character.speed = 3f;
                }
            }
            else if(nma.transform.position.x > character.transform.position.x)
            {
                Vector3 localScaleCharacter = transform.localScale;
                Vector3 localScaleNMA = transform.localScale;
                localScaleCharacter.x *= 1f;
                localScaleNMA.x *= -1f;
                nma.transform.localScale = new Vector3(localScaleNMA.x, nma.transform.localScale.y, nma.transform.localScale.z);
                character.transform.localScale = new Vector3(localScaleCharacter.x, character.transform.localScale.y, character.transform.localScale.z);
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    interacted = true;
                    character.transform.localScale = characterDirection.transform.localScale;
                    nma.isStopped = false;
                    character.speed = 3f;

                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    interacted = true;
                    character.transform.localScale = characterDirection.transform.localScale;
                    nma.gameObject.SetActive(false);
                    character.speed = 3f;
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
