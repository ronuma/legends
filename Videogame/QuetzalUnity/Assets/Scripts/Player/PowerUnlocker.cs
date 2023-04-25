using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUnlocker : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector3(-20, 0, 0);
        }
    }
}
