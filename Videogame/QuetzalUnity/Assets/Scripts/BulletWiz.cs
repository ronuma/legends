using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWiz : MonoBehaviour
{
    private float force = 4f; 
    public GameObject player;
    public float damage;

    private float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, force * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= damage;
            Destroy(gameObject); 
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
