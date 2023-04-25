using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerItem : MonoBehaviour
{
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartItem());
    }

    private IEnumerator StartItem()
    {
        yield return new WaitForSeconds(50f);
         for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<ItemsBuff>().itemHealth = GetComponent<getItems>().allItems.items[items[i].GetComponent<ItemsBuff>().itemID-1].health_change;
            items[i].GetComponent<ItemsBuff>().itemMana = GetComponent<getItems>().allItems.items[items[i].GetComponent<ItemsBuff>().itemID-1].mana_change;
            items[i].GetComponent<ItemsBuff>().itemDamage = GetComponent<getItems>().allItems.items[items[i].GetComponent<ItemsBuff>().itemID-1].damage_change;
            items[i].GetComponent<ItemsBuff>().itemSpeed = GetComponent<getItems>().allItems.items[items[i].GetComponent<ItemsBuff>().itemID-1].speed_change;
        }
    }
}
