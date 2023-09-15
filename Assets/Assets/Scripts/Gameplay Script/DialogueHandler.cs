using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI textPrompt;
    public string[] lines;
    public float textSpeed;
    private int index;
    // Start is called before the first frame update
    void Awake()
    {
        textPrompt.gameObject.SetActive(false);
        textBox.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update() // Checks for player left click input.
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textBox.text == lines[index]) // Checks if the sentence has been fully displayed before proceeding to the next line
            {
                textPrompt.gameObject.SetActive(false);
                NextLine();
            }
            else // However if the sentence has yet to be completed, it will autocomplete the sentence
            {
                StopAllCoroutines();
                textBox.text = lines[index];
            }
        }
        if (textBox.text == lines[index]) // If the sentence has completed however it hasnt been clicked, it will prompt the player to left click to continue
        {
            textPrompt.gameObject.SetActive(true);
        }


    }

    public void StartDialogue() // Starts the conversation
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() // to animate the sentence to make it looks like its being typed out
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    void NextLine() // To display the next line
    {
       if(index < lines.Length - 1) // If the index is lower than the total list of dialogues, it will go to the nexxt line
        {
            index++;
            textBox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else // if there is no more dialogues after it, it would disable the dialogue system.
        {
            gameObject.SetActive(false);
        }
    }
}
