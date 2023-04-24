using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the behaviour of the bullet object. 
//It sets the bullet's direction and velocity, and checks for collision with enemies and walls.

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos; // position of the mouse cursor
    private Camera mainCam; // main camera
    private Rigidbody2D rb; // rigidbody of the bullet
    private float force = 7f; // force with which the bullet is fired
    private float damage; // damage inflicted by the bullet

    // Start is called before the first frame update
    void Start()
    {
        // get the player's damage value and the main camera
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerDamage;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        // set the bullet's direction and velocity
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        // rotate the bullet to face the direction it's travelling in
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotz);
    }

    // OnTriggerEnter2D is called when the bullet collides with a trigger collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the bullet collides with an enemy, reduce their health by the player's damage and destroy the bullet.
        if (other.gameObject.tag == "Enemies")
        {
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerDamage;
            other.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
            Destroy(gameObject); 
        }

        if (other.gameObject.tag == "Boss")
        {
            Debug.Log("HOLA");
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerDamage;
            other.gameObject.GetComponent<BOSSHealth>().enemyHealth -= damage;
            Destroy(gameObject); 
            
        }

        // If the bullet collides with a wall, destroy the bullet.
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}