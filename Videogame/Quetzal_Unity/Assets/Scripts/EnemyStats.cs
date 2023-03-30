using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float enemyDamage = 10f;
    public float enemySpeed = 5f;
    public float enemyRange = 10f;

    public DungeonGenerator dungeonGenerator;

    public void Start()
    {
        enemyHealth = enemyHealth * (dungeonGenerator.dungeonLevel);
        enemyDamage = enemyDamage * (dungeonGenerator.dungeonLevel);
        enemySpeed = enemySpeed * (dungeonGenerator.dungeonLevel);
        enemyRange = enemyRange * (dungeonGenerator.dungeonLevel);
    }
}
