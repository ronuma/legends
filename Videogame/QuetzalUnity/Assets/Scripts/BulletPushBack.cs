using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPushBack : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private float force = 10f;
    public float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = player.transform.position - transform.position;
        Vector3 rotation = transform.position - player.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotz);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().playerHealth -= damage;
            Vector2 pushbackDirection = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushbackDirection * force, ForceMode2D.Impulse);
            Destroy(gameObject); 
        }
    }
}