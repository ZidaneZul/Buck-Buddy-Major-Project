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
    public bool talkingToNpc, NPCInteracted;
    public int index;



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


        //NpcImages = new Queue<Sprite>();
        NPCDialogueBox.SetActive(false);
        npcData = NPCDataList[Random.Range(0, NPCDataList.Length)];
        arrowTest = RightArrow.GetComponent<Button>();
        Debug.Log(npcData.ScenarioType);
    }

    public void NPCRandomChance()
    {
        if (NPCInteracted)
        {
            return;
        }
        else if(Random.Range(1,2) == 1)
        {
            NPCInteracted = true;
            StartDialogue();
        }
        else
        {
            return;
        }
    }

    public void StartDialogue()
    {
        talkingToNpc = true;
        MapBtn.enabled = false;
        ShopBtn.enabled = false;
        LeftArrow.SetActive(false);
        RightArrow.SetActive(false);
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
    public void DisplayNextSentence()
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
                sentence += "bread";

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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (npcData.ScenarioType.ToString() == "Helper")
        {
            if (index == 1)
            {
                dialogues.Dequeue();
            }
        }
        if (index == 2)
        {
            dialogues.Dequeue();
        }


        //NPCImage.sprite = images;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }


    }

    public void StartPlayerInteraction()
    {
        yesButton.SetActive(true);
        noButton.SetActive(true);
        ContinueButton.SetActive(false);
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = yesResponses.Peek();
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = noResponses.Peek();

    }
    public void LeftPersonTalking()
    {
        dialogueText.text = yesResponses.Peek();
        nameText.text = npcData.FirstPersonName;
        NPCImage2.color = new Color(0.5f, 0.5f, 0.5f);
        NPCImage1.color = Color.white;
    }

    public void RightPersonTalking()
    {
        nameText.text = npcData.SecondPersonName;
        NPCImage1.color = new Color(0.5f, 0.5f, 0.5f);
        NPCImage2.color = Color.white;
    }

    public void YesChoice()
    {
        dialogueText.text = yesResponses.Peek();
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
            yesResponses.Dequeue();
            noResponses.Dequeue();

            switch (npcData.ScenarioType.ToString())
            {
                case "Scammer":
                    {
                        Debug.Log("HE'S A SCAMMER");
                        index++;


                        break;
                    }
                case "Helper":
                    {
                        Debug.Log("HE'S A HELPER");
                        index++;


                        break;
                    }

            }



        }


    }

    public void NoChoice()
    {
        dialogueText.text = noResponses.Peek();
        RightPersonTalking();

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
                        index++;
                        Debug.Log(index);
                        if(index == 2)
                        {
                            dialogues.Dequeue();

                        }
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
    IEnumerator CloseTimer()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        NPCDialogueBox.SetActive(false);
        MapBtn.enabled = true;
        ShopBtn.enabled = true;
        LeftArrow.SetActive(true);
        RightArrow.SetActive(true);
        animator.SetBool("IsOpen", false);
        npcSpawning.spawnedNpc.SetActive(false);
        talkingToNpc = false;


    }

}
