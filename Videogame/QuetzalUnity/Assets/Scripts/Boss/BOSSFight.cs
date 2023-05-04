/* Gabriel Rodriguez (April 20th, 2023 3:04 PM) 
 * This script is used to control the behavior of the boss's attacks.
 * The script includes four attack patterns for the boss, which are determined randomly, and each attack pattern fires a different type of bullet at the player. 
 * The code also includes a method to calculate the direction from the boss to the player, and a timer to control the time between boss attacks.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSFight : MonoBehaviour
{
    private float timebtwShots = 1.5f; // This variable is used to control the time between boss attacks.
    private float deadTime = 2f; // This variable is used to control how long the boss's bullets stay alive before being destroyed.
 
    public GameObject bullet;
    public GameObject bulletPushBack;
    public GameObject bulletThree;
    public GameObject bulletWiz;
    public Vector3 direction;

    public Transform firePoint; // This variable is used to store the location where the boss's bullets will be fired from.
    private float timer;
    private Rigidbody2D rb;
    private GameObject player;

    // Start is called before the first frame update
  void Start()
{
    player = GameObject.FindGameObjectWithTag("Player");
    rb = GetComponent<Rigidbody2D>();
    direction = player.transform.position - transform.position; // This line calculates the direction from the boss to the player.
    direction.Normalize(); 
}


    
void Update()
{
    timer += Time.deltaTime;
    if (timer >= timebtwShots)
    {
        int rand = Random.Range(0, 4); // Rand value is used to determine which attack pattern the boss will use.
        
        switch(rand)
        {
            case 0:
                AttackBullet();
                break;
            case 1:
                AttackBulletThree();
                break;
            case 2:
                AttackBulletWiz();
                break;
            default:
                AttackBulletPushBack();
                break;
        }

        direction = player.transform.position - transform.position;
        GetComponent<BossAttack>().Attack(direction.x, direction.y);
    }
}


    void AttackBullet() // The attack patterns for the boss.
    {
        timer = 0;
        GameObject newShot = Instantiate(bullet, firePoint.position, Quaternion.identity);
        newShot.GetComponent<EnemyBullet>().damage = GetComponent<BossStats>().enemyDamage;
        Destroy(newShot, deadTime);
    }

    void AttackBulletThree() // The attack patterns for the boss.
    {
        timer = 0;
        GameObject newShot = Instantiate(bulletThree, firePoint.position, Quaternion.identity);
        newShot.GetComponent<BulletThree>().spread = 3;
        newShot.GetComponent<BulletThree>().damage = GetComponent<BossStats>().enemyDamage;

        GameObject newShot2 = Instantiate(bulletThree, firePoint.position, Quaternion.identity);
        newShot2.GetComponent<BulletThree>().spread = -3;
        newShot2.GetComponent<BulletThree>().damage = GetComponent<BossStats>().enemyDamage;

        GameObject newShot3 = Instantiate(bulletThree, firePoint.position, Quaternion.identity);
        newShot3.GetComponent<BulletThree>().spread = 0;
        newShot3.GetComponent<BulletThree>().damage = GetComponent<BossStats>().enemyDamage;

        Destroy(newShot, deadTime);
        Destroy(newShot2, deadTime);
        Destroy(newShot3, deadTime);
    }

    void AttackBulletWiz()  // The attack patterns for the boss.
    {
        timer = 0;
        GameObject newShot = Instantiate(bulletWiz, firePoint.position, Quaternion.identity);
        newShot.GetComponent<BulletWiz>().damage = GetComponent<BossStats>().enemyDamage;
        Destroy(newShot, deadTime);
    }

    void AttackBulletPushBack() // The attack patterns for the boss.
    {
        timer = 0;
        GameObject newShot = Instantiate(bulletPushBack, firePoint.position, Quaternion.identity);
        newShot.GetComponent<BulletPushBack>().damage = GetComponent<BossStats>().enemyDamage;
        Destroy(newShot, deadTime);
    }
    

}