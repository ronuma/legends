using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBarHandler : MonoBehaviour
{
    public Canvas menuBar;

    public Image healthBar; // the image of the health bar
    public Image damageBar; // the image of the damage bar
    public Image manaBar; // the image of the mana bar
    public Image speedBar; // the image of the speed bar
    public Image defenseBar; // the image of the defense bar

    public GameObject[] players;
    public int playerIndex; // the index of the player chosen by the user

    private bool menuBarEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        menuBar.enabled = false; // hide the menu bar when the game starts
        playerIndex = PlayerPrefs.GetInt("playerChosen", 0);
        healthBar = healthBar.GetComponent<Image>(); 
        damageBar = damageBar.GetComponent<Image>();
        manaBar = manaBar.GetComponent<Image>();
        speedBar = speedBar.GetComponent<Image>();
        defenseBar = defenseBar.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !menuBarEnabled)
        // if the player presses T and the menu bar is not enabled
        {   
            menuBar.enabled = true;
            Debug.Log(Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerSpeed / 8f, 0, 1));
            healthBar.fillAmount =  Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerHealth / 700f, 0, 1);
            damageBar.fillAmount = Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerDamage / 200f, 0, 1);
            manaBar.fillAmount = Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerMana / 250f, 0, 1);
            speedBar.fillAmount = Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerSpeed / 8f, 0, 1);
            defenseBar.fillAmount = Mathf.Clamp(players[playerIndex].GetComponent<PlayerStats>().playerDefense / 300f, 0, 1);
            // This code shows the velues of the player's stats in the menu bars
            //the mathf.clmp function is in chare of clamping the values between 0 and 1, so that they never exceed them
            // we devide the current stat by the max stat to get the percentage of the stat
            menuBarEnabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.T) && menuBarEnabled)
        // if the player presses T and the menu bar is enabled
        {
            menuBar.enabled = false; // hide the menu bar
            menuBarEnabled = false; 
        }
    }

}
