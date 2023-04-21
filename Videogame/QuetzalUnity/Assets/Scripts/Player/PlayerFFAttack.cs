/* This script controls the melee attack of the Player's Final Form.
It allows the player to attack enemies with a melee weapon, 
which can cause damage to enemies within a certain range.
It includes a camera to detect the position of the mouse, an attack timer, an attack range, and damage. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFFAttack : MonoBehaviour
{
    private Camera mainCam;  // reference to main camera
    private Vector3 mousePos; // position of the mouse in the game world
    public float attackDelay = 0.5f; // time between attacks
    private float attackTimer = 0f; // timer for measuring time between attacks
    public bool canAttack = true; // flag for checking if the player can attack
    private float damage; // amount of damage the player does
    public Vector3 direction; // direction the player is facing

    public Transform attackPoint; // point from which the attack originates
    public GameObject player; // reference to the player game object
    public LayerMask enemyLayers; // layers that the enemy game object resides in
    public float attackRange = 0.5f; // range of the player's attack


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // get reference to the main camera
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); // get the position of the mouse in the game world
        direction = mousePos - transform.position; // calculate the direction of the player
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // calculate the rotation of the player
        transform.rotation = Quaternion.Euler(0, 0, rotz); // set the rotation of the player

        if (Input.GetMouseButtonDown(0) && canAttack && player.GetComponent<PlayerFinalForm>().isTransformed) // check if the player can attack and is transformed
        {
            Attack(); // initiate the attack
        }

        attackTimer += Time.deltaTime; // increment the attack timer
        if (attackTimer >= attackDelay) // check if the player can attack again
        {
            canAttack = true; // reset the canAttack flag
            attackTimer = 0; // reset the attack timer
        }
    }

    public void Attack()
    {
        if (canAttack) // check if the player can attack
        {
            damage = player.GetComponent<PlayerStats>().playerDamage; // get the player's damage
            canAttack = false; // set the canAttack flag to false
            player.GetComponent<PlayerAttack>().Attack(direction.x, direction.y); // initiate the attack animation
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // get an array of all enemies in range of the attack
            foreach (Collider2D enemy in hitEnemies) // loop through each enemy in range of the attack
            {
                enemy.GetComponent<EnemyHealth>().enemyHealth -= damage; // subtract the player's damage from the enemy's health
            }
        }
    }
}
