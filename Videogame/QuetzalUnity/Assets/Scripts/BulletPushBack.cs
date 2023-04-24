using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPushBack : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private float force = 10f;
    private float impulse = 100f;
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
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushbackDirection * impulse, ForceMode2D.Impulse); 
            StartCoroutine(StopPushBack(other));
        }
    }

    private IEnumerator StopPushBack(Collider2D other)
    {
        yield return new WaitForSeconds(0.1f);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Destroy(gameObject);
    }
}