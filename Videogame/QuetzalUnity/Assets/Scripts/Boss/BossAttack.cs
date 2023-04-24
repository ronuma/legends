using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Animator animator;

    public void Attack(float coordX, float coordY)
    {
        animator.SetFloat("Attack-X", coordX);
        animator.SetFloat("Attack-y", coordY);
        animator.SetTrigger("Attack");
        
    }
}
