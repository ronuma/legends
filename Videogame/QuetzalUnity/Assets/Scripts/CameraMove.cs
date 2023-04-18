/*
This script attaches to the camera object and follows the player object, keeping a constant offset from it.
It uses the LateUpdate() method to ensure that the camera updates after the player has moved.
The offset is calculated in Start() by subtracting the player's position from the camera's position.

Note: The script assumes that the player object has a tag of "Player"

Both the player and camera should be aligned with each other in the scene view for this script to work properly.
*/

using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; // The offset between the player and camera

    void Start()
    {
        // Find the player object and calculate the offset
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Update the camera position to match the player's position with the offset applied
        transform.position = player.transform.position + offset;
    }
}