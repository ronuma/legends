using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBarHandler : MonoBehaviour
{
    public Canvas menuBar;

    public Image healthBar;
    public Image damageBar;
    public Image manaBar;
    public Image speedBar;
    public Image defenseBar;

    public GameObject[] players;
    public int playerIndex;

    private bool menuBarEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        menuBar.enabled = false;
        playerIndex = PlayerPrefs.GetInt("playerChosen", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !menuBarEnabled)
        {   
            menuBar.enabled = true;
            healthBar.fillAmount =  Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerHealth / 700f, 0, 1);
            damageBar.fillAmount = Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerDamage / 200f, 0, 1);
            manaBar.fillAmount = Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerMana / 250f, 0, 1);
            speedBar.fillAmount = Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerSpeed / 8f, 0, 1);
            defenseBar.fillAmount = Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerDefense / 300f, 0, 1);
            menuBarEnabled = true;
            Debug.Log("Health" + Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerHealth / 700f, 0, 1));
            Debug.Log("Damage" + Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerDamage / 200f, 0, 1));
            Debug.Log("Mana" + Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerMana / 250f, 0, 1));
            Debug.Log("Speed" + Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerSpeed / 8f, 0, 1));
            Debug.Log("Defense" + Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerDefense / 300f, 0, 1));

        }
        else if (Input.GetKeyDown(KeyCode.T) && menuBarEnabled)
        {
            menuBar.enabled = false;
            menuBarEnabled = false;
        }
    }

}