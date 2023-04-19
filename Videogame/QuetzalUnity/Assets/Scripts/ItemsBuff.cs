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

    public Sprite itemImage;

    public void Start()
    {
        itemHealth = itemHealth * Random.Range(0.7f, 1.3f);
        itemHealth = itemHealth * Random.Range(0.7f, 1.3f);
        itemMana = itemMana * Random.Range(0.7f, 1.3f);
        itemDamage = itemDamage * Random.Range(0.7f, 1.3f);
        itemSpeed = itemSpeed * Random.Range(0.7f, 1.3f);
        itemDefense = itemDefense * Random.Range(0.7f, 1.3f);
    }

}


