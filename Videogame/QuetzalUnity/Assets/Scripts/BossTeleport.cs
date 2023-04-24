using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport: MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public GameObject bossEnemy;

    private GameObject cloneBoss = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = new Vector3(80, 71, 0);
            //bossEnemy.transform.position = new Vector3(60, 71, 0);
            cloneBoss = Instantiate(bossEnemy, new Vector3(60, 71, 0), Quaternion.identity);
        }
    }
}