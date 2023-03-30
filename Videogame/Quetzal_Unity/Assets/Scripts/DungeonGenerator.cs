using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    public int dungeonLevel = 1;
    private GameObject player;
    public GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + dungeonLevel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DungeonMap[] dungeonMaps = FindObjectsOfType<DungeonMap>();
            foreach (DungeonMap map in dungeonMaps)
            {
                Destroy(map.gameObject);
            }
            dungeonLevel++;
            levelText.text = "Level: " + dungeonLevel;  

            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(-20, 0, 0);
            chest.transform.position = new Vector3(144, 0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MapGenerator[] mapGenerators = FindObjectsOfType<MapGenerator>();
            foreach (MapGenerator map in mapGenerators)
            {
                map.createMap();
            } 
        }
    }
}

