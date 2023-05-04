using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSmovement : MonoBehaviour
{
    public float speed;
    private float dist;
    public Animator animator;

    public List<Vector3> directionsList;

    private float timer;
    private float timebtwMove= 3f;

    private int rand;

    void Start()
    {
        speed = GetComponent<BossStats>().enemySpeed;
        rand = Random.Range(0, directionsList.Count);
    }

    void Update()
    {   
        timer += Time.deltaTime;
        if (timer >= timebtwMove) // This line checks if the timer is greater than or equal to the time between moves.
        {
            rand = Random.Range(0, directionsList.Count);
            timer = 0;
        }
        moveToPlace(directionsList[rand]);
        
    }

    private void moveToPlace(Vector3 dir)
    {
        //dist = Vector3.Distance(transform.position, dir);
        Vector2 direction = dir - transform.position;
        
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime); // This line moves the boss towards the player.
        transform.rotation = Quaternion.identity;
    }
}
