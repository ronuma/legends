using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBuff : MonoBehaviour
{
    public float itemHealth = 15f;
    public float itemMana = 50f;
    public float itemDamage = 20f;
    public float itemSpeed = 1f;
    public float itemDefense = 4f;

    public Sprite itemImage;

    public void Start()
    {
        itemHealth = itemHealth * Random.Range(0.7f, 1.3f);
        itemMana = itemMana * Random.Range(0.7f, 1.3f);
        itemDamage = itemDamage * Random.Range(0.7f, 1.3f);
        itemSpeed = itemSpeed * Random.Range(0.7f, 1.3f);
        itemDefense = itemDefense * Random.Range(0.7f, 1.3f);
    }

}


