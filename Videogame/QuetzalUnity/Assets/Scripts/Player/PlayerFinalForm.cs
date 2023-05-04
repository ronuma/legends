/*  Gabriel Rodriguez (March 30th, 2023 2:16 PM) 
 * Player Final Form Transformation and Power-up Script
 * This script controls the player's transformation into the Final Form.
 * It allows the player to transform into the Final Form, which grants the player increased speed, damage, and health.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalForm : MonoBehaviour
{
    public Animator animator; // A reference to the animator component
    private Camera mainCam; // A reference to the main camera

    private bool canTranform = false; // A flag for indicating if the player can transform
    private float chargeTimer; // A timer for the charge bar
    private float chargeTime = 10f; // The time for the charge bar

    public bool isTransformed; // A flag for indicating if the player is transformed

    private float durationTimer; // A timer for the duration of the transformation
    private float duration = 20f; // The duration of the transformation
    
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTranform)
        {
            chargeTimer += Time.deltaTime; // Update the charge bar
            if (chargeTimer >= chargeTime)
            {
                canTranform = true; // Reset the charge bar
                chargeTimer = 0;
            }
        }
       

        if (Input.GetKeyDown(KeyCode.E) && canTranform)
        {
            isTransformed = true;
            animator.SetBool("FinalForm", true); // Set the animation trigger
            canTranform = false;

            GetComponent<PlayerStats>().playerDamage = GetComponent<PlayerStats>().playerDamage * 3;
            // Increase the player's damage
            GetComponent<PlayerStats>().playerHealth = GetComponent<PlayerStats>().playerHealth * 3;
            // Increase the player's health
        }

        if (isTransformed)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer >= duration)
            {
                isTransformed = false; // Reset the duration timer
                durationTimer = 0;
                animator.SetBool("FinalForm", false);
                GetComponent<PlayerStats>().playerDamage = GetComponent<PlayerStats>().playerDamage / 3;
                // Returns the player's damage
                GetComponent<PlayerStats>().playerHealth = GetComponent<PlayerStats>().playerHealth / 3;
                // Returns the player's health
            }
        }
    }
}

