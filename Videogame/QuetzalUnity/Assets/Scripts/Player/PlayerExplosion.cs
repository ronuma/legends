/* Gabriel Rodriguez (April 13th, 2023 1:30 PM) 
 * Unity Script for Player Explosion with Charge Bar and Damage RadiusS
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExplosion : MonoBehaviour
{
    private Image chargeBar; //image of the charge bar
    private bool canExplode = false; //flag for indicating if the player can explode
    private float chargeTimer; //timer for the charge bar
    private float chargeTime = 10f; //time for the charge bar

    private float radio = 10f; //radio of the explosion
    private float fuerza; //damage of the explosion
    public LayerMask enemyLayers; //layers of the enemies
    public Animator animator;

    void Start()
    {
        fuerza = GetComponent<PlayerStats>().playerMana; //get the damage of the explosion
        chargeBar = GameObject.Find("Explosion").GetComponent<Image>(); //get the image of the charge bar
    }

    void Update()
    {
        if (!canExplode)
        {
            chargeTimer += Time.deltaTime; //update the charge bar
            chargeBar.fillAmount = Mathf.Clamp(chargeTimer / chargeTime, 0, 1); //clamp the charge bar
            if (chargeTimer >= chargeTime)
            {
                canExplode = true;
                chargeTimer = 0;
                chargeBar.fillAmount = 1; //reset the charge bar
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Movement>().move == Vector2.zero && canExplode)
        //if the player presses the space key, is not moving and can explode
        {
            Explode();
            animator.SetTrigger("Expo");
            canExplode = false;
        }
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radio, enemyLayers);
        //get all the enemies in the explosion radius
        foreach (Collider2D collider in colliders)
        {
            collider.GetComponent<EnemyHealth>().enemyHealth -= fuerza;
            //damage the enemies
        } 
    }
}
