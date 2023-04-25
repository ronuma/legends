/*
This script generates a new dungeon level when the player enters a trigger area.
It finds all objects with the "DungeonMap" component and destroys them to clear the previous level.
It then increments the dungeon level and updates the level text on the screen.
It repositions the player and chest objects to their starting positions in the new level.
When the player exits the trigger area, it finds all objects with the "MapGenerator" component and generates a new map.

Note: The script assumes that the player and chest objects have the "Player" and "Chest" tags respectively.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    public float dungeonLevel = 1f;
    private GameObject player;
    public GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial level text to the current dungeon level
        levelText.text = "Level: " + dungeonLevel;
    }

    // Handle trigger enter events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (dungeonLevel == 1f)
            {
                Debug.Log("Level 1");
                player.transform.position = new Vector3(321, 69, 0);
            }
            else if (dungeonLevel == 3f)
            {
                player.transform.position = new Vector3(321, 0, 0);
            }
            else if (dungeonLevel == 5f)
            {
                player.transform.position = new Vector3(321, -65, 0);
            }
            else
            {
                player.transform.position = new Vector3(-20, 0, 0);
                chest.transform.position = new Vector3(144, 0, 0);
            }
            
            DungeonMap[] dungeonMaps = FindObjectsOfType<DungeonMap>();
            foreach (DungeonMap map in dungeonMaps)
            {
                Destroy(map.gameObject);
            }
            dungeonLevel++;
        }
    }

    // Handle trigger exit events
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelText.text = "Level: " + dungeonLevel;
            // Generate a new map by calling the createMap() method on all MapGenerator objects
            MapGenerator[] mapGenerators = FindObjectsOfType<MapGenerator>();
            foreach (MapGenerator map in mapGenerators)
            {
                map.createMap();
            }
        }
    }
}