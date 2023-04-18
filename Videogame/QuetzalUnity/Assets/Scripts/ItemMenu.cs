/* This script is used to display an item menu when the player enters a trigger zone.
When triggered, the script instantiates three items randomly from an array of prefabs, and displays their stats in a UI text field
and their images in UI Image fields.

Brief comments are added for each variable and function to make the code more readable.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    // Array of item prefabs
    public GameObject[] items;

    // UI elements to display item stats and images
    public TMPro.TextMeshProUGUI statsTextRight;
    public TMPro.TextMeshProUGUI statsTextLeft;
    public TMPro.TextMeshProUGUI statsTextCenter;
    public Image imageRight;
    public Image imageCenter;
    public Image imageLeft;

    // UI canvas for the item menu
    public Canvas menu;

    // Three instantiated items
    public GameObject cloneItem1 = null;
    public GameObject cloneItem2 = null;
    public GameObject cloneItem3 = null;

    void Start()
    {
        // Set the item menu to inactive and hide all UI elements
        menu.gameObject.SetActive(false);
        statsTextRight.text = "";
        statsTextLeft.text = "";
        statsTextCenter.text = "";
        imageRight.gameObject.SetActive(false);
        imageLeft.gameObject.SetActive(false);
        imageCenter.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Set the item menu to active
            menu.gameObject.SetActive(true);

            // Instantiate three random items from the array and start their effects
            cloneItem1 = Instantiate(items[Random.Range(0, items.Length)]);
            cloneItem2 = Instantiate(items[Random.Range(0, items.Length)]);
            cloneItem3 = Instantiate(items[Random.Range(0, items.Length)]);

            cloneItem1.GetComponent<ItemsBuff>().Start();
            cloneItem2.GetComponent<ItemsBuff>().Start();
            cloneItem3.GetComponent<ItemsBuff>().Start();

            // Display item stats in UI text fields
            statsTextRight.text = "HP: " + Mathf.RoundToInt(cloneItem1.GetComponent<ItemsBuff>().itemHealth) +
                                "<br> SPD: " + Mathf.RoundToInt(cloneItem1.GetComponent<ItemsBuff>().itemSpeed) +
                                "<br> DEF: " + Mathf.RoundToInt(cloneItem1.GetComponent<ItemsBuff>().itemDefense) +
                                "<br> ATK:" + Mathf.RoundToInt(cloneItem1.GetComponent<ItemsBuff>().itemDamage) +
                                "<br> MN: " + Mathf.RoundToInt(cloneItem1.GetComponent<ItemsBuff>().itemMana);

            statsTextLeft.text = "HP: " + Mathf.RoundToInt(cloneItem2.GetComponent<ItemsBuff>().itemHealth) +
                                "<br> SPD: " + Mathf.RoundToInt(cloneItem2.GetComponent<ItemsBuff>().itemSpeed) +
                                "<br> DEF: " + Mathf.RoundToInt(cloneItem2.GetComponent<ItemsBuff>().itemDefense) +
                                "<br> ATK:" + Mathf.RoundToInt(cloneItem2.GetComponent<ItemsBuff>().itemDamage) +
                                "<br> MN: " + Mathf.RoundToInt(cloneItem2.GetComponent<ItemsBuff>().itemMana);

            statsTextCenter.text = "HP: " + Mathf.RoundToInt(cloneItem3.GetComponent<ItemsBuff>().itemHealth) +
                                "<br> SPD: " + Mathf.RoundToInt(cloneItem3.GetComponent<ItemsBuff>().itemSpeed) +
                                "<br> DEF: " + Mathf.RoundToInt(cloneItem3.GetComponent<ItemsBuff>().itemDefense) +
                                "<br> ATK:" + Mathf.RoundToInt(cloneItem3.GetComponent<ItemsBuff>().itemDamage) +
                                "<br> MN: " + Mathf.RoundToInt(cloneItem3.GetComponent<ItemsBuff>().itemMana);

            imageRight.sprite = cloneItem1.GetComponent<ItemsBuff>().itemImage;
            imageRight.gameObject.SetActive(true);
            imageLeft.sprite = cloneItem2.GetComponent<ItemsBuff>().itemImage;
            imageLeft.gameObject.SetActive(true);
            imageCenter.sprite = cloneItem3.GetComponent<ItemsBuff>().itemImage;
            imageCenter.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            menu.gameObject.SetActive(false);
            statsTextRight.text = "";
            statsTextLeft.text = "";
            statsTextCenter.text = "";
            imageRight.gameObject.SetActive(false);
            imageLeft.gameObject.SetActive(false);
            imageCenter.gameObject.SetActive(false);

            Destroy(cloneItem1);
            Destroy(cloneItem2);
            Destroy(cloneItem3);
        }
    }

}
