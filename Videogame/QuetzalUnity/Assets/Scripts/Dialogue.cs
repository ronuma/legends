using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;
    public TMP_Text textDialague;
    public List<string> dialogueList;

    private int dialogueIndex = 0;
    private int characterIndex = 0;

    private bool WaitForInput = false;

    void Start()
    {
        HideDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && WaitForInput)
        {
                if (dialogueIndex < dialogueList.Count-1)
                {
                    WaitForInput = false;
                    textDialague.text = string.Empty;
                    dialogueIndex++;
                    characterIndex = 0;
                    StartCoroutine(ShowText());
                }
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
