using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRange : MonoBehaviour
{
    public float speed;
    private float dist;
    public GameObject player;

    private float distToPlayer;
    public float distToStop;

    void Start()
    {
        distToStop = GetComponent<EnemyStats>().enemyRange;
        speed = GetComponent<EnemyStats>().enemySpeed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {    
        distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distToPlayer > distToStop)
        {
            moveToPlayer(1);
        }
        else if (distToPlayer < distToStop)
        {
            moveToPlayer(-1);
        }
    }

    private void moveToPlayer(int dir)
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * dir * Time.deltaTime);
        transform.rotation = Quaternion.identity;
    }
}
