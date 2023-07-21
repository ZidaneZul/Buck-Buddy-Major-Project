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
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textBox.text == lines[index])
            {
                textPrompt.gameObject.SetActive(false);
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textBox.text = lines[index];
            }
        }
        if (textBox.text == lines[index])
        {
            textPrompt.gameObject.SetActive(true);
        }


    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    void NextLine()
    {
       if(index < lines.Length - 1)
        {
            index++;
            textBox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
