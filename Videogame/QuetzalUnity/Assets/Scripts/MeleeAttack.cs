/* This script allows the player to attack enemies with a melee weapon. The script first gets a reference to the camera to get the mouse position in world coordinates. The script checks for player input to attack with the weapon. The script then checks for enemies in range using a circle collision detection. If an enemy is detected, the enemy's health is reduced by the player's damage. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public float attackDelay = 0.5f;
    private float attackTimer = 0f;
    public bool canAttack = true;
    private float damage;
    public Vector3 direction;
    public Transform attackPoint;
    public GameObject player;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);

        // Check for player input to attack with the weapon
        if (Input.GetMouseButtonDown(0) && canAttack && !player.GetComponent<PlayerFinalForm>().isTransformed)
        {
            Attack();
        }

        // Keep track of when the player can attack again
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            canAttack = true;
            attackTimer = 0;
        }
    }

    // Method to handle the attack
    public void Attack()
    {
        if (canAttack)
        {
            // Get player's damage and reset the attack cooldown
            damage = player.GetComponent<PlayerStats>().playerDamage;
            canAttack = false;

            // Attack animation
            player.GetComponent<PlayerAttack>().Attack(direction.x, direction.y);

            // Check for enemies in range and damage them
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.gameObject.tag == "Boss")
                {
                    enemy.GetComponent<BOSSHealth>().enemyHealth -= damage;
                    Debug.Log(enemy.GetComponent<BOSSHealth>().enemyHealth);
                }
                if (enemy.gameObject.tag == "Enemy")
                {
                    enemy.GetComponent<EnemyHealth>().enemyHealth -= damage;
                }
            }
        }
    }
}