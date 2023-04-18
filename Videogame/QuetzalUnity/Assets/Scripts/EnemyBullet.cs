/*
This script defines the behavior of enemy bullets in the game.
It assigns a velocity to the bullet, based on the position of the player.
It also handles collisions with the player and walls, dealing damage to the player
if hit and destroying the bullet in either case.

Note: The script assumes that the player object has a tag of "Player"
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private float force = 10f;
    public float damage; // The amount of damage the bullet deals to the player

    // Start is called before the first frame update
    void Start()
    {
        // Find the player object and get the rigidbody component
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        // Calculate the direction from the bullet to the player and normalize it
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        // Rotate the bullet towards the player
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);
    }

    // Handle collisions with the player and walls
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Reduce the player's health and destroy the bullet
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= damage;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            // Destroy the bullet if it hits a wall
            Destroy(gameObject);
        }
    }
}