using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    public Vector2 move;

    private bool isDashing = false; // Is the player dashing?
    private bool canDash = true; // Can the player dash?
    private float dashTime = 0.3f; // How long the dash lasts
    private float dashSpeed = 20f; // How fast the player dashes
    private float dashCooldown = 1f; // How long the cooldown lasts

    public Animator animator;
    [SerializeField] private TrailRenderer trail; // Reference to the trail renderer

    void Update()
    {      
        speed = GetComponent<PlayerStats>().playerSpeed;
        move.x = Input.GetAxis("Horizontal"); // Get the horizontal input
        move.y = Input.GetAxis("Vertical"); // Get the vertical input

        animator.SetFloat("Horizontal", move.x); // Set the animator's horizontal parameter to the horizontal input
        animator.SetFloat("Vertical", move.y); // Set the animator's vertical parameter to the vertical input
        animator.SetFloat("Speed", move.sqrMagnitude); // Set the animator's speed parameter to the square magnitude of the move vector

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !isDashing) 
        // If the player presses the left shift key, can dash and is not dashing
        {
            StartCoroutine(Dash()); // Start the dash coroutine
        } 

        transform.Translate(move * speed * Time.deltaTime); // Move the player
        transform.rotation = Quaternion.identity; // Set the player's rotation to 0
    }

    private void FixedUpdate() // FixedUpdate is called once per physics update
    {
        if (isDashing) 
        {
            transform.Translate(move * speed * Time.deltaTime); // Move the player
        }
    }

    private IEnumerator Dash() // Coroutine for the dash
    {
        isDashing = true;
        canDash = false;
        trail.emitting = true;
        speed = dashSpeed; // Set the speed to the dash speed
        yield return new WaitForSeconds(dashTime); 
        speed = GetComponent<PlayerStats>().playerSpeed; // Reset the speed to the player's normal speed
        trail.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown); // Wait for the cooldown
        canDash = true; // Reset the canDash variable
    }
}
