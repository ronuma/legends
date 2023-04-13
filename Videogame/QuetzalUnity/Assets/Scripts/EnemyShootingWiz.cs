using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingWiz : MonoBehaviour
{
    private float timebtwShots = 4f;
    private float deadTime = 5f;
    public GameObject bullet;
    public Transform firePoint;
    GameObject newShot;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timebtwShots)
        {
            timer = 0;
            GameObject newShot = Instantiate(bullet, firePoint.position, Quaternion.identity);
            newShot.GetComponent<BulletWiz>().damage = GetComponent<EnemyStats>().enemyDamage;
            Destroy(newShot, deadTime);
        }
    }
}
