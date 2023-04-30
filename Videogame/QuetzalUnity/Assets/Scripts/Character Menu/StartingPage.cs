using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingPage : MonoBehaviour
{
    public Canvas startingPage;
    public Canvas session;
    public Canvas menu;
    public TMPro.TextMeshProUGUI startingPageText;
    public TMPro.TextMeshProUGUI pressSpace;
    public string textTittle;
    public string text;

    bool newGame = true;

    void Start()
    {
        startingPage.enabled = true;
        session.enabled = false;
        menu.enabled = false;
    }

    void Update()
    {
        if (Time.time % 1 < 0.5)
        {
            startingPageText.text = " ";
            pressSpace.text = " ";
        }
        else
        {
            startingPageText.text= textTittle;
            pressSpace.text = text;
        }

        if (Input.GetKeyDown(KeyCode.Space) && newGame)
        {
            startingPage.enabled = false;
            session.enabled = true;
        }

    }

}