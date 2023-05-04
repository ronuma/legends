using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Animator animator; // This line declares a public variable called animator of type Animator, which is a class that controls animations for game objects.

    public void Attack(float coordX, float coordY)
    {
        animator.SetFloat("Attack-X", coordX);
        animator.SetFloat("Attack-y", coordY);
        animator.SetTrigger("Attack"); // This line sets the Attack trigger on the animator object, which plays the corresponding animation.
        
    }
}
