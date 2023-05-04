/* This script defines the behavior of the boss's walls in the game.
When a player collides with the wall, their health is reduced by a specified amount. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSwalls : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= 20;
        }
    }
}
