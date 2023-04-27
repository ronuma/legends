using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterButton : MonoBehaviour
{
    private GameObject player;
    private GameObject menu;
    private GameObject item;

    public GameObject updatePlayerAPI;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        menu = GameObject.FindGameObjectWithTag("Menu");
    }

    public void OnClickChoose()
    {
        item = menu.GetComponent<ItemMenu>().cloneItem3;

        applyItem();
        menu.GetComponent<ItemMenu>().menu.gameObject.SetActive(false);
        menu.transform.position = new Vector3(-100, 0, 0);
    }

    private void applyItem()
    {
        player.GetComponent<PlayerStats>().playerHealth += item.GetComponent<ItemsBuff>().itemHealth;
        player.GetComponent<PlayerStats>().playerSpeed += item.GetComponent<ItemsBuff>().itemSpeed;
        player.GetComponent<PlayerStats>().playerDefense += item.GetComponent<ItemsBuff>().itemDefense;
        player.GetComponent<PlayerStats>().playerDamage += item.GetComponent<ItemsBuff>().itemDamage;
        player.GetComponent<PlayerStats>().playerMana += item.GetComponent<ItemsBuff>().itemMana;

        var result = player.GetComponent<PlayerStats>().playerHealth > 0 ? player.GetComponent<PlayerStats>().playerHealth : 1;
        var result2 = player.GetComponent<PlayerStats>().playerMana > 0 ? player.GetComponent<PlayerStats>().playerMana : 1;
        var result3 = player.GetComponent<PlayerStats>().playerDamage > 0 ? player.GetComponent<PlayerStats>().playerDamage : 1;
        var result4 = player.GetComponent<PlayerStats>().playerSpeed > 0 ? player.GetComponent<PlayerStats>().playerSpeed : 1;
        var result5 = player.GetComponent<PlayerStats>().playerDefense > 0 ? player.GetComponent<PlayerStats>().playerDefense : 1;

        player.GetComponent<PlayerStats>().playerHealth = result;
        player.GetComponent<PlayerStats>().playerMana = result2;
        player.GetComponent<PlayerStats>().playerDamage = result3;
        player.GetComponent<PlayerStats>().playerSpeed = result4;
        player.GetComponent<PlayerStats>().playerDefense = result5;

        player.GetComponent<PlayerHealth>().ResetHealth();

        updatePlayerAPI.GetComponent<UpdatePlayerStats>().createStats(player.GetComponent<PlayerStats>().playerHealth, 
                                                                      player.GetComponent<PlayerStats>().playerMana, 
                                                                      player.GetComponent<PlayerStats>().playerDamage, 
                                                                      player.GetComponent<PlayerStats>().playerSpeed, 
                                                                      player.GetComponent<PlayerStats>().playerDefense,
                                                                      player.GetComponent<PlayerStats>().playerSession_id,
                                                                      item.GetComponent<ItemsBuff>().itemID);
    }
}


