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
    public GameObject[] objects; // array of game objects to spawn
    public GameTrack gameTrack; // reference to the game track object
    private bool rep = false; // flag to prevent repeat spawns
    public void Update()
    {
        // if the game is active and a spawn hasn't been repeated
        if (gameTrack.gameStatus && !rep)
        {
            rep = true; // set flag to true to prevent repeat spawns
            int rand = Random.Range(0, objects.Length); // choose random object index
            // instantiate chosen object and start EnemyStats component
            Instantiate(objects[rand], transform.position, Quaternion.identity).GetComponent<EnemyStats>().Start();
            Debug.Log(objects[rand]); // print object name to console for debugging
        }
    }
}