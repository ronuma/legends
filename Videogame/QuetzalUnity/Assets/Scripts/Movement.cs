using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    public Vector2 move;

    private bool isDashing = false;
    private bool canDash = true;
    private float dashTime = 0.3f;
    private float dashSpeed = 20f;
    private float dashCooldown = 1f;

    public Animator animator;
    [SerializeField] private TrailRenderer trail;

    void Update()
    {      
        speed = GetComponent<PlayerStats>().playerSpeed;
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !isDashing)
        {
            StartCoroutine(Dash());
        } 

        transform.Translate(move * speed * Time.deltaTime);
        transform.rotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            transform.Translate(move * speed * Time.deltaTime);
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        trail.emitting = true;
        speed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        speed = GetComponent<PlayerStats>().playerSpeed;
        trail.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
