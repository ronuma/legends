using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour
{
    private GameObject player;
    private GameObject menu;
    private GameObject item;
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
        player.GetComponent<PlayerStats>().playerHealth += item.GetComponent<ItemsBuff>().itemHealth;
        player.GetComponent<PlayerStats>().playerSpeed += item.GetComponent<ItemsBuff>().itemSpeed;
        player.GetComponent<PlayerStats>().playerDefense += item.GetComponent<ItemsBuff>().itemDefense;
        player.GetComponent<PlayerStats>().playerDamage += item.GetComponent<ItemsBuff>().itemDamage;
        player.GetComponent<PlayerStats>().playerMana += item.GetComponent<ItemsBuff>().itemMana;
    }
}


