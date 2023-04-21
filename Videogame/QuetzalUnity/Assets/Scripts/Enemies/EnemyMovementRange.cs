/*
This script controls the movement of an enemy character towards the player within a certain range.
It gets the speed and range of the enemy from the "EnemyStats" component.
The Update() method calculates the distance to the player, and the moveToPlayer() method
moves the enemy towards the player if the distance is greater than the range, and away from the player if it's less.
The enemy's movement is animated with an Animator component.

Note: The script assumes that the player object has a tag of "Player".
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRange : MonoBehaviour
{
    public float speed; // The speed at which the enemy moves
    private float dist; // The distance to the player
    public GameObject player; // Reference to the player object
    public Animator animator; // Reference to the Animator component

    private float distToPlayer; // The distance to the player
    public float distToStop; // The range at which the enemy stops moving towards the player

    void Start()
    {
        // Get the speed and range of the enemy from the EnemyStats component
        distToStop = GetComponent<EnemyStats>().enemyRange;
        speed = GetComponent<EnemyStats>().enemySpeed;

        // Find the player object
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Calculate the distance to the player
        distToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Move towards the player if the distance is greater than the range, and away from the player if it's less
        if (distToPlayer > distToStop)
        {
            moveToPlayer(1);
        }
        else if (distToPlayer < distToStop)
        {
            moveToPlayer(-1);
        }
    }

    // Move the enemy towards or away from the player
    private void moveToPlayer(int dir)
    {
        // Calculate the direction and distance to the player
        dist = Vector3.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        // Set the animation parameters based on the direction and speed of movement
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);

        // Move the enemy towards or away from the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * dir * Time.deltaTime);
        transform.rotation = Quaternion.identity;
    }

}