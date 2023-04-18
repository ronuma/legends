using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
// An array of map prefabs to choose from
public GameObject[] maps;
// Create the map on start
public void Start()
{
    createMap();
}

// Create a new map by instantiating a random map prefab from the maps array
public void createMap()
{
    int rand = Random.Range(0, maps.Length);
    Instantiate(maps[rand], transform.position, Quaternion.identity);
}  
}