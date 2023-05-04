/* This script manages the enemy objects in game and sets its stats from the API
call in the file getEnemyStatsApi.cs, then it sets the stats to the enemy objects
with normal and boss stats
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemies : MonoBehaviour
{
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartEnemies());
    }

    private IEnumerator StartEnemies()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (i<=2)
            {
            enemies[i].GetComponent<EnemyStats>().enemyHealth = GetComponent<getEnemyStatsApi>().allEnemyStatsApis.enemystatsapis[i].health;
            enemies[i].GetComponent<EnemyStats>().enemyDamage = GetComponent<getEnemyStatsApi>().allEnemyStatsApis.enemystatsapis[i].damage;
            enemies[i].GetComponent<EnemyStats>().enemySpeed = GetComponent<getEnemyStatsApi>().allEnemyStatsApis.enemystatsapis[i].speed;
            }
            else
            {
            enemies[i].GetComponent<BossStats>().enemyHealth = GetComponent<getEnemyStatsApi>().allEnemyStatsApis.enemystatsapis[i].health;
            enemies[i].GetComponent<BossStats>().enemyDamage = GetComponent<getEnemyStatsApi>().allEnemyStatsApis.enemystatsapis[i].damage;
            enemies[i].GetComponent<BossStats>().enemySpeed = GetComponent<getEnemyStatsApi>().allEnemyStatsApis.enemystatsapis[i].speed;
            }
        }
    }
}