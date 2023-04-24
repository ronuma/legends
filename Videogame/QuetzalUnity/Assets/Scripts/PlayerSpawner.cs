using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefabSword;
    public GameObject playerPrefabBow;
    public GameObject playerPrefabSpear;

    public GameObject[] playerPrefabs;

    public int playerChosen;

    // Start is called before the first frame update
    void Start()
    {
        playerPrefabs = new GameObject[] { playerPrefabSword, playerPrefabBow, playerPrefabSpear };        
        Instantiate(playerPrefabs[playerChosen], transform.position, Quaternion.identity);
    }

}
