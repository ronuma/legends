using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the enemy's health
// It checks if the enemy's health is less than or equal to zero and destroys the enemy game object if it is.

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth; // The current health of the enemy
    public float maxHealth; // The maximum health of the enemy
    private GameTrack gameTrack; // A reference to the game track script
   void Start()
{
    enemyHealth = maxHealth; // Set the enemy's health to the maximum health
    enemyHealth = GetComponent<EnemyStats>().enemyHealth; // Get the enemy's health from the enemy stats script
}


void Update()
{
    if (enemyHealth <= 0) // If the enemy's health is less than or equal to zero
    {
        Destroy(gameObject); // Destroy the enemy game object
    }
}
}