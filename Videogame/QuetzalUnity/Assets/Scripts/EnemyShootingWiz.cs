using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the enemy's shooting
// It creates a new bullet at the enemy's fire point and destroys it after a set time.

public class EnemyShootingWiz : MonoBehaviour
{
    private float timebtwShots = 4f;   // The time between each shot
    private float deadTime = 5f;       // The time after which the bullet is destroyed
    public GameObject bullet;         // The bullet prefab to shoot
    public Transform firePoint;       // The position where the bullet is fired from
    GameObject newShot;               // The bullet object that is instantiated
    private float timer;              // The timer used to track the time between shots

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;       // Increment the timer by the time elapsed since the last frame
        if (timer >= timebtwShots)     // If the time since the last shot is greater than the time between shots
        {
            timer = 0;                 // Reset the timer
            GameObject newShot = Instantiate(bullet, firePoint.position, Quaternion.identity);  // Instantiate the bullet prefab at the fire point
            newShot.GetComponent<BulletWiz>().damage = GetComponent<EnemyStats>().enemyDamage;  // Set the damage of the bullet to the enemy's damage value
            Destroy(newShot, deadTime);  // Destroy the bullet object after a set amount of time
        }
    }
}