/*
This script defines the stats of an enemy character, including health, damage, speed, and range.
It multiplies the stats based on the current dungeon level, obtained from the DungeonGenerator component.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth = 100f; // The health of the enemy
    public float enemyDamage = 10f; // The damage the enemy deals to the player
    public float enemySpeed = 5f; // The speed at which the enemy moves
    public float enemyRange = 10f; // The range at which the enemy starts attacking the player

    public DungeonGenerator dungeonGenerator; // Reference to the DungeonGenerator component

    public void Start()
    {
        // Multiply the stats based on the current dungeon level
        enemyHealth = enemyHealth * (dungeonGenerator.dungeonLevel);
        enemyDamage = enemyDamage * (dungeonGenerator.dungeonLevel);
        enemySpeed = enemySpeed * (dungeonGenerator.dungeonLevel);
        enemyRange = enemyRange * (dungeonGenerator.dungeonLevel);
    }
}