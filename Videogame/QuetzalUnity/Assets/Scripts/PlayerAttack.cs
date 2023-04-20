/* This script handles the player's melee attack animation. When called, the Attack() function sets the parameters for the animation
based on the direction of the mouse cursor, and triggers the "Attack" animation.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    // Function to set the attack direction and trigger the "Attack" animation
    public void Attack(float coordX, float coordY)
    {
        animator.SetFloat("Attack-X", coordX);
        animator.SetFloat("Attack-y", coordY);
        animator.SetTrigger("Attack");
    }
}