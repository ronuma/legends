using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSwalls : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= 20;
        }
    }
}
