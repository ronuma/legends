using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBuff : MonoBehaviour
{
    // Public variables to hold the values for item health, mana, damage, speed and defense
    public float itemHealth = 15f;
    public float itemMana = 50f;
    public float itemDamage = 20f;
    public float itemSpeed = 1f;
    public float itemDefense = 4f;

    // Public variable to hold the sprite for the item
    public Sprite itemImage;

    // Start is called before the first frame update
    public void Start()
    {
        // Randomly add a modficiation of 30% to the item's stats
        itemHealth = itemHealth * Random.Range(0.7f, 1.3f);
        itemMana = itemMana * Random.Range(0.7f, 1.3f);
        itemDamage = itemDamage * Random.Range(0.7f, 1.3f);
        itemSpeed = itemSpeed * Random.Range(0.7f, 1.3f);
        itemDefense = itemDefense * Random.Range(0.7f, 1.3f);
    }

}


