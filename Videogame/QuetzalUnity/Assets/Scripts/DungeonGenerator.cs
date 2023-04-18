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
    [SerializeField] TMPro.TextMeshProUGUI levelText; // Reference to the level text on the UI
    public int dungeonLevel = 1; // The current dungeon level
    private GameObject player; // Reference to the player object
    public GameObject chest; // Reference to the chest object

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
            // Destroy all DungeonMap objects to clear the previous level
            DungeonMap[] dungeonMaps = FindObjectsOfType<DungeonMap>();
            foreach (DungeonMap map in dungeonMaps)
            {
                Destroy(map.gameObject);
            }

            // Increment the dungeon level and update the level text
            dungeonLevel++;
            levelText.text = "Level: " + dungeonLevel;

            // Reposition the player and chest objects to their starting positions in the new level
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(-20, 0, 0);
            chest.transform.position = new Vector3(144, 0, 0);
        }
    }

    // Handle trigger exit events
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Generate a new map by calling the createMap() method on all MapGenerator objects
            MapGenerator[] mapGenerators = FindObjectsOfType<MapGenerator>();
            foreach (MapGenerator map in mapGenerators)
            {
                map.createMap();
            }
        }
    }
}