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
        levelText.text = "Level: " + dungeonLevel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (dungeonLevel == 5)
            {
                player.transform.position = new Vector3(320, 0, 0);
            }
            else
            {
            DungeonMap[] dungeonMaps = FindObjectsOfType<DungeonMap>();
            foreach (DungeonMap map in dungeonMaps)
            {
                Destroy(map.gameObject);
            }
            dungeonLevel++;
            levelText.text = "Level: " + dungeonLevel;  

            player.transform.position = new Vector3(-20, 0, 0);
            chest.transform.position = new Vector3(144, 0, 0);
            }
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

