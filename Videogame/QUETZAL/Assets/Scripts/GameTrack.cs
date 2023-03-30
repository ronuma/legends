using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrack : MonoBehaviour
{
    public bool gameStatus = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameStatus = true;
        }
    }
}
