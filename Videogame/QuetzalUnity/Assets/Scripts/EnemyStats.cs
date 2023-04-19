using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth;
    public float enemyDamage;
    public float enemySpeed;
    public float enemyRange;

    private GameObject dungeonGenerator;

    public void Start()
    {
        dungeonGenerator = GameObject.FindGameObjectWithTag("DungeonGenerator");
        enemyHealth = enemyHealth * (dungeonGenerator.GetComponent<DungeonGenerator>().dungeonLevel/2);
        enemyDamage = enemyDamage * (dungeonGenerator.GetComponent<DungeonGenerator>().dungeonLevel/2);
    }
}