using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingThree : MonoBehaviour
{
    private float timebtwShots = 1.5f;
    private float deadTime = 2f;
    public GameObject bullet;
    public Transform firePoint;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timebtwShots)
        {
            timer = 0;
            GameObject newShot = Instantiate(bullet, firePoint.position, Quaternion.identity);
            newShot.GetComponent<BulletThree>().spread = 3;
            newShot.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage;

            GameObject newShot2 = Instantiate(bullet, firePoint.position, Quaternion.identity);
            newShot2.GetComponent<BulletThree>().spread = -3;
            newShot2.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage;

            GameObject newShot3 = Instantiate(bullet, firePoint.position, Quaternion.identity);
            newShot3.GetComponent<BulletThree>().spread = 0;
            newShot3.GetComponent<BulletThree>().damage = GetComponent<EnemyStats>().enemyDamage;

            Destroy(newShot, deadTime);
            Destroy(newShot2, deadTime);
            Destroy(newShot3, deadTime);
        }
    }
}
