/*
This script controls the shooting behavior of an enemy character that shoots three bullets in a spread pattern.
It defines the time between shots and the duration of the bullets before they disappear.
The Update() method checks if the time between shots has passed, and if so, 
instantiates three bullets at the firePoint position.
The bullets are given a spread value and damage based on the EnemyStats component.
The bullets are destroyed after the deadTime duration.

Note: The script assumes that the bullet prefab has a "BulletThree" component.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingThree : MonoBehaviour
{
    private float timebtwShots = 1.5f; // The time between each shot
    private float deadTime = 2f; // The time before the bullets disappear
    public GameObject bullet; // Reference to the bullet prefab
    public Transform firePoint; // Reference to the fire point transform
    private float timer; // The current time since the last shot
                         // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Shoot three bullets in a spread pattern if the time between shots has passed
        if (timer >= timebtwShots)
        {
            timer = 0;
            GameObject newShot = Instantiate(bullet, firePoint.position, Quaternion.identity);
            newShot.GetComponent<BulletThree>().spread = 3; // Set the spread value of the first bullet
            newShot.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage; // Set the damage of the bullet based on the EnemyStats component

            GameObject newShot2 = Instantiate(bullet, firePoint.position, Quaternion.identity);
            newShot2.GetComponent<BulletThree>().spread = -3; // Set the spread value of the second bullet
            newShot2.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage; // Set the damage of the bullet based on the EnemyStats component

            GameObject newShot3 = Instantiate(bullet, firePoint.position, Quaternion.identity);
            newShot3.GetComponent<BulletThree>().spread = 0; // Set the spread value of the third bullet
            newShot3.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage; // Set the damage of the bullet based on the EnemyStats component

            // Destroy the bullets after the deadTime duration
            Destroy(newShot, deadTime);
            Destroy(newShot2, deadTime);
            Destroy(newShot3, deadTime);
        }
    }
}