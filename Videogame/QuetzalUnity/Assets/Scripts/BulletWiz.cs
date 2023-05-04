/* This script defines the behavior of bullets in the game.

The bullet moves towards the player at a constant speed and updates its
animation. Upon collision with the player, the bullet deals damage and is
destroyed. If the bullet collides with a wall, it is also destroyed. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWiz : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    private float force = 4f; // Bullet speed
    public GameObject player; // Reference to the player GameObject
    public float damage; // Amount of damage this bullet deals to the player
    private float distance; // Distance between the bullet and the player

    void Start()
    {
        // Find the player GameObject in the scene and assign it to the player
        // variable
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Calculate the distance between the bullet and the player
        distance = Vector3.Distance(transform.position, player.transform.position);

        // Calculate the direction from the bullet to the player
        Vector2 direction = player.transform.position - transform.position;

        // Move the bullet towards the player with a constant speed
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, force * Time.deltaTime);

        animator.SetFloat("Mov-x", direction.x);
        animator.SetFloat("speed", Mathf.Abs(direction.x));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the bullet collides with the player, damage the player and destroy
        // the bullet
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= damage;
            Destroy(gameObject); 
        }

        // If the bullet collides with a wall, destroy the bullet
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}