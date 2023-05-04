/* This script handles the triggering of dialogue in the game.
When the player enters the designated trigger area, the dialogue is displayed.
When the player exits the trigger area, the dialogue is hidden. 

It is used on NPC's and Kukulkan.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogue;

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogue.GetComponent<Dialogue>().ShowDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogue.GetComponent<Dialogue>().HideDialogue();
        }
    }
}
