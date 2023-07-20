using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using TMPro;
public class NPCRandomChance : MonoBehaviour
{
    Scene currentScene;
    string SceneName;
    NPCRandomChance randomChance;
    public GameObject[] NPC;
    public GameObject NPCOnScene;
    public string[] Dialogues;
    public GameObject[] SpawnPoints;
    public NavMeshAgent nma;
    public GameObject Player;
    public int SpawnPointLocation = 0;
    public bool patrol;
    public Transform target;
    public CharacterScript character;
    public Collider[] collidedObjects;
    public bool interacted;
    public int randomNPC;
    public GameObject dialogueBox;
    public GameObject dialogueBoxInScene;
    public TextMeshPro NPCText;
    public bool yes;

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
        if(GameObject.FindGameObjectWithTag("NPC") != null)
        {
            GotoNextPoint();
        }
        if ((PlayerDetection()))
        {
            TestDialogue();
        }
        if (GameObject.FindGameObjectWithTag("NPC") == null)
        {
            StartCoroutine(NPCSpawner(SceneName));

        }



        SceneChanged();
        TemporaryButton();
        

    }
    void FixedUpdate()
    {

        if (NPCOnScene != null)
        {
            collidedObjects = Physics.OverlapSphere(nma.transform.position, 3f);
        }

    }

    IEnumerator NPCSpawner(string NPCtoSpawn)
    {
        if(NPCtoSpawn == "SampleScene")
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (NPCtoSpawn == "Level1")
        {
            randomNPC = Random.Range(0, NPC.Length);
            SpawnPointLocation = Random.Range(0, SpawnPoints.Length);
            Debug.Log("A random NPC Appears");
            Instantiate(NPC[randomNPC],SpawnPoints[SpawnPointLocation].transform);
            Instantiate(dialogueBox);
            NPCOnScene = GameObject.FindGameObjectWithTag("NPC");
            nma = NPCOnScene.GetComponent<NavMeshAgent>();
            nma.stoppingDistance = 0.25f;
            dialogueBoxInScene = GameObject.FindGameObjectWithTag("textBox");
            NPCText = GameObject.FindGameObjectWithTag("textBox").GetComponentInChildren<TextMeshPro>();
            yield return new WaitForSeconds(3f);
            dialogueBoxInScene.SetActive(false);
            StopAllCoroutines();

        }
    }
    bool PlayerDetection()
    {
        float distance = 5f;

        if (NPCOnScene != null)
        {
            foreach (Collider k in collidedObjects)
            {
                if (k.gameObject.tag == "Player")
                {
                    Player = k.gameObject;
                    character = k.gameObject.GetComponent<CharacterScript>();
                    return true;
                }

            }

        }

        return false;
    }


    void GotoNextPoint()
    {
        if (!PlayerDetection())
        {
            if (NPCOnScene != null)
            {
                if (SpawnPointLocation == 0)
                {
                    dialogueBoxInScene.SetActive(false);
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
                    dialogueBoxInScene.SetActive(false);
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
                    dialogueBoxInScene.SetActive(false);
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
                    yes = true;
                    nma.isStopped = false;
                    character.transform.localScale = characterDirection.transform.localScale;
                    character.speed = 3f;
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    interacted = true;
                    yes = false;
                    nma.isStopped = false;
                    character.transform.localScale = characterDirection.transform.localScale;
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
                    yes = true;
                    character.transform.localScale = characterDirection.transform.localScale;
                    nma.isStopped = false;
                    character.speed = 3f;

                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    interacted = true;
                    yes = false;
                    nma.isStopped = false;
                    character.transform.localScale = characterDirection.transform.localScale;
                    character.speed = 3f;
                }
            }
        }

    }

    void TestDialogue()
    {
        int NPCTypeHolder = 0;
        dialogueBoxInScene.SetActive(true);
        dialogueBoxInScene.transform.rotation.SetLookRotation(Camera.main.transform.position);
        dialogueBoxInScene.transform.position = new Vector3(NPCOnScene.transform.position.x,(NPCOnScene.transform.position.y+5f), NPCOnScene.transform.position.z);


        for (int i = 0; i < NPC.Length; i++)
        {
            Debug.Log(i);

            if (i == randomNPC)
            {
                NPCTypeHolder = i;
                NPCText.text = Dialogues[i*3];


            }

        }

        if (interacted == true && yes == true)
        {
            NPCText.text = Dialogues[NPCTypeHolder * 3 + 1];

        }
        if (interacted == true && yes == false)
        {
            NPCText.text = Dialogues[NPCTypeHolder * 3 + 2 ];

        }

    }


    

    void SceneChanged()
    {
        if(SceneManager.GetActiveScene() != currentScene)
        {
            StopAllCoroutines();
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
