using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canShoot;
    public float shootDelay;
    private float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;

        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, rotz);

        if (!canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootDelay)
            {
                canShoot = true;
                shootTimer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            GameObject newBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            Destroy(newBullet,3f);
        }
    }
}

