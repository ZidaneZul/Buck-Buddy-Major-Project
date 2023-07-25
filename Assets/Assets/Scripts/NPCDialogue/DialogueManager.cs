using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogues;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image NPCImage;
    public Animator animator;
    public bool NPCInteracted;
    public GameObject NPCDialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
        NPCDialogueBox.SetActive(false);
    }

    public void NPCRandomChance(Dialogue dialogue)
    {
        if (NPCInteracted)
        {
            return;
        }
        else if(Random.Range(1,3) == 2)
        {
            NPCInteracted = true;
            StartDialogue(dialogue);
        }
        else
        {
            return;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        NPCDialogueBox.SetActive(true);
        animator.SetBool("IsOpen", true);
        Debug.Log("Starting Conversation with" + dialogue.NPCname);
        dialogues.Clear();
        NPCImage.sprite = dialogue.NPCimage;
        nameText.text = dialogue.NPCname;
        foreach(string sentences in dialogue.dialogues)
        {
            dialogues.Enqueue(sentences);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = dialogues.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
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
        NPCDialogueBox.SetActive(false);
        animator.SetBool("IsOpen", false);
    }
}
