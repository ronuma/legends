/* Gabriel Rodriguez (March 30th, 2023 2:16 PM)
 * This script is responsible for the shooting mechanics of a player in a game. 
 * It handles the player's ability to shoot bullets and sets the direction of the bullets based on the mouse position relative to the player.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    private Camera mainCam; // The main camera in the scene
    private Vector3 mousePos; // The position of the mouse in the game world
    public GameObject bullet; // Prefab of the bullet that the player will shoot
    public Transform bulletTransform; // The transform of the bullet object
    public bool canShoot; // A flag that determines if the player can shoot or not
    public float shootDelay; // The delay time between shots
    private float shootTimer; // A timer to keep track of the delay between shots
    public GameObject player; // The player object

    // Start is called before the first frame update
    void Start()
    {
        // Find the main camera in the scene and store its reference in mainCam
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Convert the mouse position on screen to a position in the game world
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        // Calculate the direction of the bullet based on the difference between the player's position and the mouse position
        Vector3 direction = mousePos - transform.position;
        // Calculate the rotation angle of the player based on the direction of the bullet
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Set the rotation of the player based on the calculated angle
        transform.rotation = Quaternion.Euler(0, 0, rotz);

        if (!canShoot)
        {
            // If the player cannot shoot, start a timer to keep track of the delay between shots
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootDelay)
            {
                // If the delay time has passed, the player can shoot again
                canShoot = true;
                shootTimer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canShoot && !player.GetComponent<PlayerFinalForm>().isTransformed)
        {
            // If the left mouse button is pressed, the player can shoot, and the player is not transformed, call the Attack method of the player object to trigger an attack animation
            player.GetComponent<PlayerAttack>().Attack(direction.x, direction.y);
            // Delay the bullet instantiation to give time for the attack animation to play
            Invoke("Shoot", 0.3f);
        }
    }

    private void Shoot()
    {
        // Set the canShoot flag to false to prevent the player from shooting again immediately
        canShoot = false;
        // Instantiate a new bullet object at the position of the bulletTransform
        GameObject newBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        // Destroy the bullet object after a set amount of time
        Destroy(newBullet, 3f);
    }
}