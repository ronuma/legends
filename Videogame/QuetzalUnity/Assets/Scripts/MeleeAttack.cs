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
        transform.rotation = Quaternion.Euler(0,0, rotz);

        if (Input.GetMouseButtonDown(0) && canAttack && !player.GetComponent<PlayerFinalForm>().isTransformed)
        {
            Attack();
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            canAttack = true;
            attackTimer = 0;
        }
    }

    public void Attack()
    {
        if (canAttack)
        {
            damage = player.GetComponent<PlayerStats>().playerDamage;
            canAttack = false;
            player.GetComponent<PlayerAttack>().Attack(direction.x, direction.y);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().enemyHealth -= damage;
            }
        }
    }
}
