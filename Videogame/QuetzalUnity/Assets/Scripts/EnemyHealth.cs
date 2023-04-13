using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float maxHealth;
    private GameTrack gameTrack;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
        enemyHealth = GetComponent<EnemyStats>().enemyHealth;
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
