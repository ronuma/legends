using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefabBow;
    public GameObject playerPrefabSword;
    public GameObject playerPrefabSpear;

    public GameObject[] playerPrefabs;

    public int playerChosen;

    // Start is called before the first frame update
    void Start()
    {
        playerChosen = PlayerPrefs.GetInt("playerChosen", 0);
        playerPrefabs = new GameObject[] {playerPrefabSpear, playerPrefabBow, playerPrefabSword};  
        Debug.Log(playerChosen);       
        Instantiate(playerPrefabs[playerChosen], transform.position, Quaternion.identity);
    }

}
