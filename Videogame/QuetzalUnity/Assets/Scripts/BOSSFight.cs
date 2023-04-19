using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSFight : MonoBehaviour
{
    private float timebtwShots = 1.5f;
    private float deadTime = 2f;

    public GameObject bullet;
    public GameObject BulletPushBack;
    public GameObject bulletThree;
    public GameObject bulletWiz;

    public Transform firePoint;
    private float timer;
    private Rigidbody2D rb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = player.transform.position - transform.position;
        Vector3 rotation = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timebtwShots)
        {
            int rand = Random.Range(0, 3);
            switch(rand)
            {
                case 0:
                    AttackBullet(bullet);
                    break;
                case 1:
                    AttackBulletThree();
                    break;
                case 2:
                    AttackBulletWiz();
                    break;
                case 3:
                    AttackBullet(BulletPushBack);
                    break;
            }
        }
    }

    void AttackBullet(GameObject bull)
    {
        timer = 0;
        GameObject newShot = Instantiate(bull, firePoint.position, Quaternion.identity);
        newShot.GetComponent<EnemyBullet>().damage = GetComponent<EnemyStats>().enemyDamage;
        Destroy(newShot, deadTime);
    }

    void AttackBulletThree()
    {
        timer = 0;
        GameObject newShot = Instantiate(bulletThree, firePoint.position, Quaternion.identity);
        newShot.GetComponent<BulletThree>().spread = 3;
        newShot.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage;

        GameObject newShot2 = Instantiate(bulletThree, firePoint.position, Quaternion.identity);
        newShot2.GetComponent<BulletThree>().spread = -3;
        newShot2.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage;

        GameObject newShot3 = Instantiate(bulletThree, firePoint.position, Quaternion.identity);
        newShot3.GetComponent<BulletThree>().spread = 0;
        newShot3.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage;

        Destroy(newShot, deadTime);
        Destroy(newShot2, deadTime);
        Destroy(newShot3, deadTime);
    }

    void AttackBulletWiz()
    {
        timer = 0;
        GameObject newShot = Instantiate(bulletWiz, firePoint.position, Quaternion.identity);
        newShot.GetComponent<BulletWiz>().damage = GetComponent<EnemyStats>().enemyDamage;
        Destroy(newShot, deadTime);
    }

    

}
