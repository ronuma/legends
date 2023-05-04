/* This script defines the behavior of a bullet that pushes the player back upon collision. 
(Used by the boss)
The bullet is given a velocity based on the player's position, and it rotates towards the player.
When the bullet collides with the player, it deals damage, applies a pushback force, and then
stops the pushback after a short duration. The bullet is destroyed after the pushback is stopped. 

The blue bullet is the one that pushes the player back.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script defines the behavior of a bullet that pushes the player back upon collision
//the bullet is given a velocity based on the player's position, and it rotates towards the player
public class BulletPushBack : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player; // the player
    private float force = 10f; // the force of the bullet
    private float impulse = 100f; // the pushBack of the bullet
    public float damage; // the damage of the bullet

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = player.transform.position - transform.position;
        Vector3 rotation = transform.position - player.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        //all the previous code is to give the bullet a velocity based on the player's position
        //and to rotate the bullet towards the player

        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotz);
    }

    private void OnTriggerEnter2D(Collider2D other) // when the bullet collides with the player
    {
        if (other.gameObject.tag == "Player") 
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= damage;
            Vector2 pushbackDirection = (other.transform.position - transform.position).normalized; 
            //the direction of the pushback is the opposite of the direction of the bullet
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushbackDirection * impulse, ForceMode2D.Impulse); 
            //apply the pushback force to the position of the player
            StartCoroutine(StopPushBack(other));
            //stop the pushback after a short duration
        }
    }

    private IEnumerator StopPushBack(Collider2D other)
    {
        yield return new WaitForSeconds(0.1f); //duration of the pushback
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero; //stop the pushback
        Destroy(gameObject); //destroy the bullet
    }
}