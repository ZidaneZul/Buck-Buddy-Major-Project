using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> dialogues, dialogueNames,yesResponses,noResponses;
    public Queue<bool> leftSideTalking,StartingOptions;
    public Queue<bool> rightSideTalking;
    public TextMeshProUGUI nameText, dialogueText;
    public Image NPCImage1,NPCImage2;
    public Animator animator;
    public NPCData[] NPCDataList;
    public NPCData npcData;
    public GameObject yesButton, noButton, ContinueButton, LeftArrow, RightArrow, NPCDialogueBox;
    public Button MapBtn, ShopBtn, arrowTest;
    public NPCSpawning npcSpawning;
    public bool talkingToNpc, NPCInteracted,Scammed;
    public int index;
    public GameOverScript gameOverScript;


    // Start is called before the first frame update
    void Start()
    {
        npcSpawning = GameObject.Find("GameManager").GetComponent<NPCSpawning>();
        dialogues = new Queue<string>();
        dialogueNames = new Queue<string>();
        leftSideTalking = new Queue<bool>();
        rightSideTalking = new Queue<bool>();
        StartingOptions = new Queue<bool>();
        yesResponses = new Queue<string>{};
        noResponses = new Queue<string> {};
        gameOverScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameOverScript>();


        //NpcImages = new Queue<Sprite>();
        NPCDialogueBox.SetActive(false);
        npcData = NPCDataList[Random.Range(0, NPCDataList.Length)];
        Debug.Log(npcData.ScenarioType);
    }

    // Every the player interacts with the map, there is a 1/10 chance in triggering the NPC
    public void NPCRandomChance()
    {
        if (NPCInteracted)
        {
            return;
        }
        else if(Random.Range(1,10) == 1)
        {
            NPCInteracted = true;
            StartDialogue();
        }
        else
        {
            return;
        }
    }
    public void Update()
    {
        if (talkingToNpc) // It will disable the movement keys once in a conversation
        {
            LeftArrow.SetActive(false);
            RightArrow.SetActive(false);
        }

    }

    public void StartDialogue() // Dialog trigger, Assigning all the respective variables needed for the NPC
    {
        LeftArrow.SetActive(false);
        RightArrow.SetActive(false);
        talkingToNpc = true;
        MapBtn.enabled = false;
        ShopBtn.enabled = false;
        NPCDialogueBox.SetActive(true);
        animator.SetBool("IsOpen", true);
        //Debug.Log("Starting Conversation with" + npcData.);
        dialogues.Clear();
        yesButton.SetActive(false);
        noButton.SetActive(false);
        NPCImage1.sprite = npcData.FirstPerson;
        NPCImage2.sprite = npcData.SecondPerson;

        foreach (NPCData.NpcScenario sentences in npcData.DynamicNpcScenario) 
        {
            dialogues.Enqueue(sentences.dialogue);
            Debug.Log(sentences.dialogue);
        }

        //foreach(string sentences in npcData)
        //{
        //    dialogues.Enqueue(sentences);
        //}
        //foreach(NPCData.NpcScenario names in npcData.DynamicNpcScenario)
        //{
        //    dialogueNames.Enqueue();
        //}
        foreach (string yesOptions in npcData.yes)
        {

            yesResponses.Enqueue(yesOptions);

        }
        foreach (string noOptions in npcData.no)
        {

            noResponses.Enqueue(noOptions);

        }
        foreach (NPCData.NpcScenario WhosTalking1 in npcData.DynamicNpcScenario)
        {
            Debug.Log(WhosTalking1.FirstImage);

            leftSideTalking.Enqueue(WhosTalking1.FirstImage);

        }
        foreach (NPCData.NpcScenario WhosTalking2 in npcData.DynamicNpcScenario)
        {
            rightSideTalking.Enqueue(WhosTalking2.SecondImage);
        }
        foreach (NPCData.NpcScenario DecisionStarter in npcData.DynamicNpcScenario)
        {
            StartingOptions.Enqueue(DecisionStarter.PlayerInteraction);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence() // Dequeues the latest variable and move on to the next sequence
    {
        if(dialogues.Count == 0)
        {
            StartCoroutine(CloseTimer());
            return;
        }


        string sentence = dialogues.Dequeue();
        bool WhosTalking1 = leftSideTalking.Dequeue();
        bool WhosTalking2 = rightSideTalking.Dequeue();
        bool DecisionStarter = StartingOptions.Dequeue();

        if (DecisionStarter)
        {
            if (npcData.ScenarioType.ToString() == "Helper")
            {
                sentence += InventoryManager.Instance.NPCFindMissingItem();

            }
            StartPlayerInteraction();

        }
        if (WhosTalking1)
        {
            LeftPersonTalking();

        }

        if (WhosTalking2)
        {
            RightPersonTalking();

        }
        if (index == 1)
        {
            dialogues.Dequeue();
            switch (npcData.ScenarioType.ToString())
            {
                case "Scammer":
                    {

                        break;
                    }
                case "Helper":
                    {

                        sentence += MapDataList.instance.GetAisle(InventoryManager.Instance.NPCFindMissingItem());

                        break;
                    }
            }
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        





        //NPCImage.sprite = images;
    }

    IEnumerator TypeSentence(string sentence) // Animating the text to make it look like its typing
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }


    }

    public void StartPlayerInteraction() // Displays the yes and no options
    {
        yesButton.SetActive(true);
        noButton.SetActive(true);
        ContinueButton.SetActive(false);
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = yesResponses.Peek();
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = noResponses.Peek();

    }
    public void LeftPersonTalking() // Dims out the right person when left is talking
    {
        nameText.text = npcData.FirstPersonName;
        NPCImage2.color = new Color(0.5f, 0.5f, 0.5f);
        NPCImage1.color = Color.white;
    }

    public void RightPersonTalking() // Dims out the left person when right is talking
    {
        nameText.text = npcData.SecondPersonName;
        NPCImage1.color = new Color(0.5f, 0.5f, 0.5f);
        NPCImage2.color = Color.white;
    }

    public void YesChoice() // When player press Yes, conduct respective yes outcomes
    {

        LeftPersonTalking();

        if (dialogues.Count == 0)
        {
            StartCoroutine(CloseTimer());
        }
        else
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            ContinueButton.SetActive(true);

            switch (npcData.ScenarioType.ToString())
            {
                case "Scammer":
                    {
                        Debug.Log("HE'S A SCAMMER");
                        dialogueText.text = "Okay, heres all my money";
                        yesResponses.Dequeue();
                        noResponses.Dequeue();
                        Scammed = true;
                        index++;


                        break;
                    }
                case "Helper":
                    {
                        Debug.Log("HE'S A HELPER");
                        dialogueText.text = yesResponses.Peek();
                        yesResponses.Dequeue();
                        noResponses.Dequeue();
                        index++;

                        break;
                    }

            }



        }


    }

    public void NoChoice() // When player press no, carry out respective no outcomes.
    {
        dialogueText.text = noResponses.Peek();
        LeftPersonTalking();

        if (dialogues.Count == 0)
        {
            StartCoroutine(CloseTimer());
        }
        else
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            ContinueButton.SetActive(true);
            noResponses.Dequeue();
            yesResponses.Dequeue();

            switch (npcData.ScenarioType.ToString())
            {
                case "Scammer":
                    {
                        Debug.Log("HE'S A SCAMMER");
                        dialogues.Dequeue();

                        break;
                    }
                case "Helper":
                    {
                        Debug.Log("HE'S A HELPER");
                        dialogues.Dequeue();

                        break;
                    }

            }
        }

    }
    IEnumerator CloseTimer() // Close all UI related to the NPC
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        NPCDialogueBox.SetActive(false);
        MapBtn.enabled = true;
        ShopBtn.enabled = true;
        LeftArrow.SetActive(true);
        RightArrow.SetActive(true);
        animator.SetBool("IsOpen", false);
        talkingToNpc = false;
        if (Scammed)
        {
            gameOverScript.levelBudget -= gameOverScript.levelBudget;
        }
        npcSpawning.spawnedNpc.SetActive(false);



    }

}
