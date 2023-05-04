/*

This script is attached to a StartingPage object in the game scene.
It handles the behavior of the starting page, which is the first screen
that the player sees when starting the game.
The script defines several public variables that represent UI elements,
such as Canvas and TextMeshProUGUI objects, and two string variables
for the starting page text and title.
The Update method controls the display of the starting page text and title
using the Time class to toggle the text on and off. When the player presses
the space bar, the starting page is disabled, and the session screen is enabled.

*/


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