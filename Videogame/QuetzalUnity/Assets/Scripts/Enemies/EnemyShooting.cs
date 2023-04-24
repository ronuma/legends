using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the enemy's shooting
// It creates a new bullet at the enemy's fire point and destroys it after a set time.

public class EnemyShooting : MonoBehaviour
{
    private float timebtwShots = 1f; // time between enemy shots
    private float deadTime = 2f; // time until enemy bullets are destroyed
    public GameObject bullet; // enemy bullet prefab
    public Transform firePoint; // where enemy bullets come out from
    GameObject newShot; // reference to the new bullet created
    private float timer; // timer to keep track of time between shots

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // update timer with time passed since last frame
        if (timer >= timebtwShots) // if time between shots has passed
        {
            timer = 0; // reset timer
            // create new bullet at fire point, set its damage to enemy's damage, and destroy it after a set time
            GameObject newShot = Instantiate(bullet, firePoint.position, Quaternion.identity);
            newShot.GetComponent<EnemyBullet>().damage = GetComponent<EnemyStats>().enemyDamage;
            Destroy(newShot, deadTime);
        }
    }
}
