using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExplosion : MonoBehaviour
{
    private Image chargeBar;
    private bool canExplode = true;
    private float chargeTimer;
    private float chargeTime = 10f;

    private float radio = 10f;
    private float fuerza;
    public LayerMask enemyLayers;
    public Animator animator;

    void Start()
    {
        fuerza = GetComponent<PlayerStats>().playerMana;
        chargeBar = GameObject.Find("Explosion").GetComponent<Image>();
    }

    void Update()
    {
        if (!canExplode)
        {
            chargeTimer += Time.deltaTime;
            chargeBar.fillAmount = Mathf.Clamp(chargeTimer / chargeTime, 0, 1);
            if (chargeTimer >= chargeTime)
            {
                canExplode = true;
                chargeTimer = 0;
                chargeBar.fillAmount = 1;
            }
        }
         
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Movement>().move == Vector2.zero && canExplode)
        {
            Explode();
            animator.SetTrigger("Expo");
            canExplode = false;
        }
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radio, enemyLayers);
        foreach (Collider2D collider in colliders)
        {
            collider.GetComponent<EnemyHealth>().enemyHealth -= fuerza;
        } 
    }
}
