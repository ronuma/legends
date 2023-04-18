using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script defines the behavior of the third type of bullet in the game. 
It assigns a velocity to the bullet, based on the position of the player and a spread value. 
It also handles collisions with the player and walls, dealing damage to the player 
if hit and destroying the bullet in either case.
*/

public class BulletThree : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private float force = 7f;
    public float spread;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = player.transform.position - transform.position;
        Vector3 rotation = transform.position - player.transform.position;
        rb.velocity = new Vector2(direction.x + spread, direction.y + spread).normalized * force;

        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= damage;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
