/* This script manages the creation and destruction of the door object in the
game, which is used to transition between dungeon levels. The door is created
when the game is active and there are no enemies in the scene. If the game is
active and no enemies are present, the door object is destroyed. A flag is used
to ensure that a new door is only created once per dungeon. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the creation of the door object. It checks if the game is
// active and if there are no enemies in the scene.

public class CreateDoor : MonoBehaviour
{
    public GameObject door1; // Prefab for the door object
    public GameTrack gameTrack; // Reference to the GameTrack script for tracking game status
    private GameObject cloneDoor; // Clone of the door object
    private bool rep = false; // Flag for indicating if a new door should be created

    void Update()
    {
        if (gameTrack.gameStatus)
        {
            if (GameObject.FindGameObjectWithTag("Enemies") == null) // Check if there are no enemies in the scene
            {
                Destroy(cloneDoor); // Destroy the cloned door if there are no enemies in the scene
            }
        }

        if (gameTrack.gameStatus && !rep) // Check if the game is active and a new door has not been created
        { 
            rep = true; // Set flag to indicate that a new door has been created
            cloneDoor = Instantiate(door1, transform.position, Quaternion.identity);  // Create a new door object clone at the specified location
        }
    }
}