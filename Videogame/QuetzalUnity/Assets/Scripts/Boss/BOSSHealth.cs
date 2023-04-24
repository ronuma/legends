using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSHealth : MonoBehaviour
{
    public float enemyHealth;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
        enemyHealth = GetComponent<BossStats>().enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}