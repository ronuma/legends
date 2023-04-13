using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public GameTrack gameTrack;
    private bool rep = false;

    public void Update()
    {
        if (gameTrack.gameStatus && !rep)
        {
        rep = true;
        int rand = Random.Range(0, objects.Length); 
        Instantiate(objects[rand], transform.position, Quaternion.identity);  
        objects[rand].GetComponent<EnemyStats>().Start();
        Debug.Log(objects[rand]);
        }
    }
}
