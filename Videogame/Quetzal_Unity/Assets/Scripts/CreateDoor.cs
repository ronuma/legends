using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDoor : MonoBehaviour
{
    public GameObject door1;
    public GameTrack gameTrack;
    private GameObject cloneDoor;
    private bool rep = false;

    void Update()
    {
        if (gameTrack.gameStatus)
        {
            if (GameObject.FindGameObjectWithTag("Enemies")== null)
            {
                Destroy(cloneDoor);
            }
        }

        if (gameTrack.gameStatus && !rep)
        { 
        rep = true;
        cloneDoor = Instantiate(door1, transform.position, Quaternion.identity);  
        }
    }
}