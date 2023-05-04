using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefabBow; // Reference to the player prefab
    public GameObject playerPrefabSword; // Reference to the player prefab
    public GameObject playerPrefabSpear; // Reference to the player prefab    

    public GameObject[] playerPrefabs;

    public int playerChosen; // Flag to check which player was chosen

    // Start is called before the first frame update
    void Awake()
    {
        playerChosen = PlayerPrefs.GetInt("playerChosen", 0);
        //gets the player chosen by the user from the global variable "playerChosen"
        playerPrefabs = new GameObject[] {playerPrefabSpear, playerPrefabBow, playerPrefabSword};  
        Debug.Log(playerChosen);       
        Instantiate(playerPrefabs[playerChosen], transform.position, Quaternion.identity);
        //crates the player in the index that the user selected
    }

}
