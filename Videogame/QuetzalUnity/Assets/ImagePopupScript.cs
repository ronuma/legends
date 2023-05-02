using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImagePopupScript : MonoBehaviour
{
    public GameObject imagePopup; // Reference to the ImagePopup GameObject
    public bool isActive = false; // Flag to check if the popup is active
    

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

