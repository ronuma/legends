using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is responsible for keeping track of the game's status.
// It has a boolean variable gameStatus that is false by default.
// When the player enters a trigger zone with a certain tag, the gameStatus is set to true.

public class GameTrack : MonoBehaviour
{
    public bool gameStatus = false;

    // OnTriggerEnter2D is called when a Collider2D enters the trigger zone of this GameObject.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameStatus = true;
        }
    }
}



