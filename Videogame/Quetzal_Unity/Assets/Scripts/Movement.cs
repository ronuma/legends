using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    private Vector2 move;

    void Update()
    {      
        speed = GetComponent<PlayerStats>().playerSpeed;
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        transform.Translate(move * speed * Time.deltaTime);
        transform.rotation = Quaternion.identity;
    }
}
