using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] maps;

    public void Start()
    {
        createMap();
    }

    public void createMap()
    {
        int rand = Random.Range(0, maps.Length);
        Instantiate(maps[rand], transform.position, Quaternion.identity);
    }
   
}
