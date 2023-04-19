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
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(playerHealth / maxHealth, 0, 1);
        if (playerHealth <= 0)
        {
            //Destroy(gameObject);
            healthBar.fillAmount = 0;
        }
    }

    public void ResetHealth()
    {
        maxHealth = GetComponent<PlayerStats>().playerHealth;
        playerHealth = maxHealth;
    }
}
