/* Gabriel Rodriguez (April 24th, 2023 11:24 PM) 
 * Dead Canvas Script
 * This script controls the dead canvas, which is displayed when the player dies.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadCanvas : MonoBehaviour
{
    public Canvas deadCanvas; // A reference to the dead canvas
    public TMPro.TextMeshProUGUI deadCanvasText; // A reference to the text component of the dead canvas

    private bool isDead = false; // A flag for indicating if the player is dead

    void Start() // Disable the dead canvas
    {
        deadCanvas.enabled = false;
    }

    void Update() // If the player is dead, and the player presses "G", then load the game over scene
    {
        if (isDead && Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    public void EnableDeadCanvas() // Set the "isDead" variable to true, and pause the game 
    {
        isDead = true;
        deadCanvas.enabled = true;
        Time.timeScale = 0;
    }

}