/* This script defines the behavior of the boss's walls in the game.
When a player collides with the wall, their health is reduced by a specified amount. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script defines the behavior of the boss's walls in the game
//they must be tagged as "BossWalls" in the Unity editor
//they damage the player if he gets too close to them
public class BOSSwalls : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player; // the player
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // if the player collides with the wall
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= 20;
        }
    }
}
