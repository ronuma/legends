/* This script is responsible for handling the player's health 
and updating the health bar UI accordingly. The script starts 
by getting the reference to the player's health bar image and setting the
initial health value to be the maximum health value defined in the PlayerStats script.

In the Update function, the health bar fill amount is updated based 
on the current health divided by the maximum health.
If the player's health drops to zero, the health bar fill amount is set to zero as well. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    private float maxHealth;
    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>(); //get reference to the health bar image
        maxHealth = GetComponent<PlayerStats>().playerHealth; //set the maximum health value from PlayerStats
        playerHealth = maxHealth; //set the initial health value to be the maximum health value
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(playerHealth / maxHealth, 0, 1); //update the health bar fill amount based on the current health value
        if (playerHealth <= 0)
        {
            healthBar.fillAmount = 0; //set the health bar fill amount to zero if the player's health drops to zero
        }
    }
}