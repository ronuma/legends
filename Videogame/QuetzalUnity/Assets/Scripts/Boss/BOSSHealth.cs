using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSHealth : MonoBehaviour
{
    public bool isTransformed = false;
    public float enemyHealth;
    public float maxHealth;
    public Animator animator; // A reference to the animator component // A flag for indicating if the player can transform
    private float durationTimer; // A timer for the duration of the transformation

    // Start is called before the first frame update
    void Start()
    {   
        maxHealth = GetComponent<BossStats>().enemyHealth;
        enemyHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= maxHealth / 2 && !isTransformed)
        {
            Debug.Log("transform");
            isTransformed = true;
            animator.SetBool("FinalForm", true); // Set the animation trigge
            GetComponent<BossStats>().enemyDamage = GetComponent<BossStats>().enemyDamage * 2;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }        
    }
}   