using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This sript of creating a dialogue box for the game, and to create the animations of the text
public class Dialogue : MonoBehaviour
{
    public GameObject window; // the dialogue box
    public GameObject indicator; // the indicator of the dialogue box
    public TMP_Text textDialague; // the text of the dialogue box
    public List<string> dialogueList; // the list of all the dialogues of the NPC

    private int dialogueIndex = 0; // the index of the dialogue
    private int characterIndex = 0; // the index of the character

    private bool WaitForInput = false; 

    void Start()
    {
        HideDialogue(); // hide the dialogue box when the NPC is created
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && WaitForInput) 
        // if the player presses P and the prevoius dialogue has finished
        {
                if (dialogueIndex < dialogueList.Count-1)
                {
                    WaitForInput = false;
                    textDialague.text = string.Empty;
                    dialogueIndex++;
                    characterIndex = 0;
                    StartCoroutine(ShowText()); // show the next dialogue
                } //this function is in charge of showing erasing the dialogue to show the next one
                else
                {
                    HideDialogue();
                }
        }
    }

    public void ShowDialogue()
    {
        window.SetActive(true);
        indicator.SetActive(false);
        StartCoroutine(ShowText());
    }

    public void HideDialogue()
    {
        window.SetActive(false);
        indicator.SetActive(true);
        textDialague.text = string.Empty;
        dialogueIndex = 0;
        characterIndex = 0;
        StopAllCoroutines();
        WaitForInput = false;
    }


    IEnumerator ShowText()
    //this function is in charge of showing the text of the dialogue
    //it shows the text letter by letter by moving their index
    //it also waits for the player to press P to move the next dialogue
    { 
        if (!WaitForInput)
        {
            while (characterIndex <= dialogueList[dialogueIndex].Length)
            {
                textDialague.text = dialogueList[dialogueIndex].Substring(0, characterIndex);
                characterIndex++;
                yield return new WaitForSeconds(0.05f);
            }
            WaitForInput = true;
        }
    }

}
