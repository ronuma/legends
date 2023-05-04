/* This script is used to activate an easter egg image in the game.
When the player enters the designated trigger area, the image popup is displayed.
When the player exits the trigger area, the image popup is hidden.

Authored by: Alejandro A. and Gabriel R.
Last edit: 02/05/2023
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImagePopupScript : MonoBehaviour
{
    public GameObject imagePopup; // Reference to the ImagePopup GameObject
    public bool isActive = false; // Flag to check if the popup is active
    
    void Start()
    {
        imagePopup.SetActive(false); // Hide the popup on start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = true;
            Debug.Log("show image popup");
            imagePopup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = false;
            Debug.Log("hide image popup");
            imagePopup.SetActive(false);
        }
    }
}

