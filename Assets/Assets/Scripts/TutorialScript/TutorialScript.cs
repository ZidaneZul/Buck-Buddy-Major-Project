using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public GameObject GrayedBox, MapBtn, CartBtn, MovementBtn, TutorialChatBox,CoinWaypoints,DialogueWaypoints,TutorialMap,AisleButton,TextHint;
    public TextMeshProUGUI TutorialMesssage;
    public Transform TextPosition;
    public List<Transform> CoinPositions;
    public List<Transform> DialoguePositions;
    public Sprite[] DialogueBoxAssets;
    public Sprite[] CoinAssets;
    public Image CoinMascot;
    public Image DialogueBox;

    public string[] dialogueHolder;
    public string[] mapDialogueHolder;
    private Queue<string> dialogues;
    public GameObject ContinueButton;
    public int Index;
    public bool MapTriggered;

    // Start is called before the first frame update
    void Start()
    {

        dialogues = new Queue<string>();

        TextHint = GameObject.Find("TextHint");
        AisleButton = GameObject.Find("BakeryAisleBtn");
        TutorialMap = GameObject.Find("TutorialMap2");
        GrayedBox = GameObject.Find("TutorialBox");
        MapBtn = GameObject.Find("TutorialMap");
        CartBtn = GameObject.Find("TutorialCart");
        MovementBtn = GameObject.Find("TutorialMovementArrows");
        TutorialChatBox = GameObject.Find("TutorialMessage");
        CoinMascot = GameObject.Find("CoinHolder").GetComponent<Image>();
        DialogueBox = GameObject.Find("Dialogue").GetComponent<Image>();
        CoinWaypoints = GameObject.Find("CoinWaypoints");
        DialogueWaypoints = GameObject.Find("SpeechBubbleWaypoint");
        TextPosition = DialogueBox.transform.Find("TextPosition");
        TutorialMesssage = TutorialChatBox.GetComponent<TextMeshProUGUI>();
        ContinueButton = GameObject.Find("ContinueBtnTutorial");

        foreach (Transform k in CoinWaypoints.GetComponentInChildren<Transform>())
        {
            CoinPositions.Add(k);
        }
        foreach (Transform k in DialogueWaypoints.GetComponentInChildren<Transform>())
        {
            DialoguePositions.Add(k);
        }

        GrayedBox.SetActive(false);
        MapBtn.SetActive(false);
        CartBtn.SetActive(false);
        MovementBtn.SetActive(false);
        TutorialChatBox.SetActive(false);
        TutorialMap.SetActive(false);
        AisleButton.SetActive(false);
        




        if (SceneManager.GetActiveScene().name == "Level1")
        {
            //StartCoroutine(StartTutorial());
            StartDialogue();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CloseTutorial()
    {
        GrayedBox.SetActive(false);
    }

    public void MapTutorialStart()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (!MapTriggered)
            {
                TutorialChatBox.SetActive(true);
                GrayedBox.SetActive(true);
                dialogues.Clear();

                foreach (string sentences in mapDialogueHolder)
                {
                    dialogues.Enqueue(sentences);
                }

                DisplayNextSentence();

                MapTriggered = true;
            }
        }

    }

    public void StartDialogue()
    {
        TutorialChatBox.SetActive(true);
        GrayedBox.SetActive(true);
        dialogues.Clear();

        foreach (string sentences in dialogueHolder)
        {
            dialogues.Enqueue(sentences);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (dialogues.Count == 0)
        {
            StartCoroutine(CloseTimer());
            return;
        }

        Test();
        string sentence = dialogues.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Index++;

    }
    IEnumerator CloseTimer()
    {
        yield return new WaitForSeconds(1.5f);
        GrayedBox.SetActive(false);
        MapBtn.SetActive(false);
        CartBtn.SetActive(false);
        MovementBtn.SetActive(false);
        TutorialChatBox.SetActive(false);


    }

    IEnumerator TypeSentence(string sentence)
    {
        TutorialMesssage.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            TutorialMesssage.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

    }

    public void Test()
    {
        if (Index == 1)
        {
            CoinMascot.sprite = CoinAssets[1];


        }
        if (Index == 2)
        {
            CoinMascot.sprite = CoinAssets[0];
            CoinMascot.transform.position = CoinPositions[1].transform.position;
            CoinMascot.transform.localScale = new Vector3(CoinMascot.transform.localScale.x * -1, CoinMascot.transform.localScale.y, CoinMascot.transform.localScale.z);
            DialogueBox.transform.position = DialoguePositions[1].transform.position;
            DialogueBox.sprite = DialogueBoxAssets[1];
            DialogueBox.transform.localScale = new Vector3(DialogueBox.transform.localScale.x, DialogueBox.transform.localScale.y, DialogueBox.transform.localScale.z); TutorialChatBox.transform.position = TextPosition.transform.position;
            CartBtn.SetActive(true);

        }
        if (Index == 3)
        {
                    CartBtn.SetActive(false);
        MapBtn.SetActive(true);
        }
        if (Index == 4)
        {
            CoinMascot.sprite = CoinAssets[0];
            DialogueBox.sprite = DialogueBoxAssets[1];
            CoinMascot.transform.position = CoinPositions[0].transform.position;
            CoinMascot.transform.localScale = new Vector3(CoinMascot.transform.localScale.x * -1, CoinMascot.transform.localScale.y, CoinMascot.transform.localScale.z);
            DialogueBox.transform.position = DialoguePositions[0].transform.position;
            TutorialChatBox.transform.position = TextPosition.transform.position;
            DialogueBox.transform.localScale = new Vector3(DialogueBox.transform.localScale.x, DialogueBox.transform.localScale.y, DialogueBox.transform.localScale.z); TutorialChatBox.transform.position = TextPosition.transform.position;

            MapBtn.SetActive(false);
            MovementBtn.SetActive(true);


        }
        if (Index == 7)
        {
            DialogueBox.transform.position = DialoguePositions[2].transform.position;
            TutorialChatBox.transform.position = TextPosition.transform.position;
            DialogueBox.sprite = DialogueBoxAssets[2];
            CoinMascot.enabled = false;
            TutorialMap.SetActive(true);

        }
        if (Index == 8)
        {
            TutorialMap.SetActive(false);
            AisleButton.SetActive(true);
            ContinueButton.SetActive(false);
            TextHint.SetActive(false);

        }
    }
    IEnumerator StartTutorial()
    {
        GrayedBox.SetActive(true);
        TutorialChatBox.SetActive(true);
        TutorialMesssage.text = "Hello, Welcome to the first level of Smart Shopper";


        yield return new WaitForSeconds(3f);
        CoinMascot.sprite = CoinAssets[1];
        TutorialMesssage.text = "Are you ready? Lets begin.";



        yield return new WaitForSeconds(3f);
        CoinMascot.sprite = CoinAssets[0];
        CoinMascot.transform.position = CoinPositions[1].transform.position;
        CoinMascot.transform.localScale = new Vector3(CoinMascot.transform.localScale.x * -1, CoinMascot.transform.localScale.y, CoinMascot.transform.localScale.z);
        DialogueBox.transform.position = DialoguePositions[1].transform.position;
        DialogueBox.sprite = DialogueBoxAssets[1];
        DialogueBox.transform.localScale = new Vector3(DialogueBox.transform.localScale.x, DialogueBox.transform.localScale.y * -1, DialogueBox.transform.localScale.z); TutorialChatBox.transform.position = TextPosition.transform.position;
        CartBtn.SetActive(true);
        TutorialMesssage.text = "Explaining Cart Feature";


        yield return new WaitForSeconds(4f);
        CartBtn.SetActive(false);
        MapBtn.SetActive(true);
        TutorialMesssage.text = "Explaining Map Features";


        yield return new WaitForSeconds(4f);
        CoinMascot.sprite = CoinAssets[0];
        DialogueBox.sprite = DialogueBoxAssets[1];
        CoinMascot.transform.position = CoinPositions[0].transform.position;
        CoinMascot.transform.localScale = new Vector3(CoinMascot.transform.localScale.x * -1, CoinMascot.transform.localScale.y, CoinMascot.transform.localScale.z);
        DialogueBox.transform.position = DialoguePositions[0].transform.position;
        TutorialChatBox.transform.position = TextPosition.transform.position;
        DialogueBox.transform.localScale = new Vector3(DialogueBox.transform.localScale.x, DialogueBox.transform.localScale.y * -1, DialogueBox.transform.localScale.z); TutorialChatBox.transform.position = TextPosition.transform.position;

        MapBtn.SetActive(false);
        MovementBtn.SetActive(true);
        TutorialMesssage.text = "Explaining how to move";


        yield return new WaitForSeconds(4f);
        MovementBtn.SetActive(false);
        TutorialMesssage.text = "Bye bye";


        yield return new WaitForSeconds(4f);
        GrayedBox.SetActive(false);
        StopAllCoroutines();
    }
}
