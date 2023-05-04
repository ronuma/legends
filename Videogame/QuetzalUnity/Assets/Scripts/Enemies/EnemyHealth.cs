/*
This script is responsible for handling the health of an enemy game object. It checks whether the enemy's health is less than or equal to zero and destroys the enemy game object if it is. The script also initializes the enemy's health to its maximum value and retrieves the enemy's health value from the EnemyStats script.
*/

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