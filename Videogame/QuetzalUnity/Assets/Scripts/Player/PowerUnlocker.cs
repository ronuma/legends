/* Gabriel Rodriguez (March 30th, 2023 2:16 PM)
 * Power Unlocker Script for Dungeon
 * This script controls the unlocking of the power in the dungeon.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUnlocker : MonoBehaviour
{
    private GameObject player;
    public GameObject dungeonGenerator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector3(-20, 0, 0);
            if (dungeonGenerator.GetComponent<DungeonGenerator>().dungeonLevel >= 5f)
            {
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                PlayerPrefs.SetInt("BOSSOpen", 1);
            }
        }
    }
}
