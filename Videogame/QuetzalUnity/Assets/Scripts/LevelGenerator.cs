/* This script generates a new game object from an array of objects
in the scene, whenever the game status changes and the generator
hasn't already instantiated an object. The game object is randomly
chosen from the array and spawned at the position of the generator.
The Start method of the EnemyStats component on the object is then called. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public GameTrack gameTrack;
    private bool rep = false;

    public GameObject cloneEnemy;

    public void Update()
    {
        // if the game is active and a spawn hasn't been repeated
        if (gameTrack.gameStatus && !rep)
        {
        rep = true;
        int rand = Random.Range(0, objects.Length); 
        cloneEnemy = Instantiate(objects[rand], transform.position, Quaternion.identity);  
        cloneEnemy.GetComponent<EnemyStats>().Start();
        //Debug.Log(objects[rand]);
        }
    }
}