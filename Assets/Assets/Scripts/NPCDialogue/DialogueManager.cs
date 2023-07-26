using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogues;
    private Queue<string> dialogueNames;
    private Queue<Sprite> NpcImages;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image NPCImage;
    public Animator animator;
    public bool NPCInteracted;
    public GameObject NPCDialogueBox;
    public NPCData[] NPCDataList;
    public NPCData npcData;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject ContinueButton;
    public Button MapBtn;
    public Button ShopBtn;
    public GameObject LeftArrow;
    public GameObject RightArrow;
    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
        dialogueNames = new Queue<string>();
        NpcImages = new Queue<Sprite>();
        NPCDialogueBox.SetActive(false);
        npcData = NPCDataList[Random.Range(0, NPCDataList.Length)];
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
        MapBtn.enabled = false;
        ShopBtn.enabled = false;
        LeftArrow.SetActive(false);
        RightArrow.SetActive(false);
        NPCDialogueBox.SetActive(true);
        animator.SetBool("IsOpen", true);
        Debug.Log("Starting Conversation with" + npcData.NPCname);
        dialogues.Clear();
        yesButton.SetActive(false);
        noButton.SetActive(false);
        foreach (string sentences in npcData.dialogues)
        {
            dialogues.Enqueue(sentences);
        }
        foreach(string names in npcData.NPCname)
        {
            dialogueNames.Enqueue(names);
        }
        foreach(Sprite images in npcData.NPCimage)
        {
            NpcImages.Enqueue(images);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(dialogues.Count == 0)
        //dialogues.Count - npcData.LineToStopAt
        {
            EndDialogue();
            return;
        }
        string sentence = dialogues.Dequeue();
        string names = dialogueNames.Dequeue();
        Sprite images = NpcImages.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        nameText.text = names;
        NPCImage.sprite = images;
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

    public void EndDialogue()
    {

        yesButton.SetActive(true);
        noButton.SetActive(true);
        ContinueButton.SetActive(false);
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = npcData.yesResponse;
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = npcData.noResponse;

    }

    public void YesChoice()
    {
        dialogueText.text = npcData.NPCResponses[0];
        StartCoroutine(CloseTimer());

       
    }

    public void NoChoice()
    {
        dialogueText.text=npcData.NPCResponses[1];
        StartCoroutine(CloseTimer());
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

    }
}
