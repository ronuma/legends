// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ManagerStatsPlayer : MonoBehaviour
// {
//     private float playerHealth;
//     private float playerMana;
//     private float playerDamage;
//     private float playerSpeed;
//     private float playerDefense;
// }

//     private GameObject player;

// void Start()
// {
//     UpdateStats();
// }

// public void UpdateStats()
// {
//     player = GameObject.FindGameObjectWithTag("Player");
//     var patchStatsPlayer = GameObject.FindObjectOfType<patchStatsPlayer>();
//     if (patchStatsPlayer != null) {
//         patchStatsPlayer.allUsers.users[0].health = player.GetComponent<PlayerStats>().playerHealth;
//         patchStatsPlayer.allUsers.users[0].mana = player.GetComponent<PlayerStats>().playerMana;
//         patchStatsPlayer.allUsers.users[0].damage = player.GetComponent<PlayerStats>().playerDamage;
//         patchStatsPlayer.allUsers.users[0].speed = player.GetComponent<PlayerStats>().playerSpeed;
//         patchStatsPlayer.allUsers.users[0].defense = player.GetComponent<PlayerStats>().playerDefense;
//     }
// }
