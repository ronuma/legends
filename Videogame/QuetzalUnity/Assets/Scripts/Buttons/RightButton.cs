using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour
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
        item = menu.GetComponent<ItemMenu>().cloneItem1;
        
        applyItem();
        menu.GetComponent<ItemMenu>().menu.gameObject.SetActive(false);
        menu.transform.position = new Vector3(-100, 0, 0);
    }

    private void applyItem()
    {
        player.GetComponent<PlayerStats>().playerHealth = Mathf.Clamp(player.GetComponent<PlayerStats>().playerHealth + item.GetComponent<ItemsBuff>().itemHealth, 1, 999);
        player.GetComponent<PlayerStats>().playerMana = Mathf.Clamp(player.GetComponent<PlayerStats>().playerMana + item.GetComponent<ItemsBuff>().itemMana, 1, 299);
        player.GetComponent<PlayerStats>().playerDamage = Mathf.Clamp(player.GetComponent<PlayerStats>().playerDamage + item.GetComponent<ItemsBuff>().itemDamage, 1, 124);
        player.GetComponent<PlayerStats>().playerSpeed = Mathf.Clamp(player.GetComponent<PlayerStats>().playerSpeed + item.GetComponent<ItemsBuff>().itemSpeed, 1, 7.9f);
        player.GetComponent<PlayerStats>().playerDefense = Mathf.Clamp(player.GetComponent<PlayerStats>().playerDefense + item.GetComponent<ItemsBuff>().itemDefense, 1, 249);

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


