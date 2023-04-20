using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBuff : MonoBehaviour
{
    public float itemHealth;
    public float itemMana;
    public float itemDamage;
    public float itemSpeed;
    public float itemDefense;

    // Public variable to hold the sprite for the item
    public Sprite itemImage;
    public int itemID;

    // Start is called before the first frame update
    public void Start()
    {
        itemHealth = GetComponent<getItems>().allItems.items[itemID].health_change;
        itemMana = GetComponent<getItems>().allItems.items[itemID].mana_change;
        itemDamage = GetComponent<getItems>().allItems.items[itemID].damage_change;
        itemSpeed = GetComponent<getItems>().allItems.items[itemID].speed_change;

        // Randomly add a modficiation of 30% to the item's stats
        itemHealth = itemHealth * Random.Range(0.7f, 1.3f);
        itemHealth = itemHealth * Random.Range(0.7f, 1.3f);
        itemMana = itemMana * Random.Range(0.7f, 1.3f);
        itemDamage = itemDamage * Random.Range(0.7f, 1.3f);
        itemSpeed = itemSpeed * Random.Range(0.7f, 1.3f);
        itemDefense = itemDefense * Random.Range(0.7f, 1.3f);
    }

}


