/*
This script attaches to the camera object and follows the player object, keeping a constant offset from it. 
It uses the LateUpdate() method to ensure that the camera updates after the player has moved. 
The offset is calculated in Start() by subtracting the player's position from the camera's position.

Note: The script assumes that the player object has a tag of "Player"

Both the player and camara should be aligned with each other in the scene view for this script to work properly.
*/
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}