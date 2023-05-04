/* Gabriel Rodriguez (April 24th, 2023 11:24 PM) 
 * ScenesSwitcher
 * This script allows for switching between scenes, checking if a specific scene is open and whether a boss battle is open or not.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSwitcher : MonoBehaviour
{
    public int sceneIndex; 
    public int bossBattleOpen = 0; 

    void Start()
    {
        Time.timeScale = 1; // Set the time scale to 1
    }

    void Update() // 
    {
        bossBattleOpen = PlayerPrefs.GetInt("BOSSOpen", 0); // Check if the boss battle is open
    }

    private void OnTriggerEnter2D(Collider2D other) // If the player enters the collider, then load the scene
    {
        if (other.gameObject.tag == "Player")
        {
            if (sceneIndex == 4 && bossBattleOpen == 1) // If the boss battle is open, then load the boss battle scene
            {
                SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single); 
            }

            if (sceneIndex != 4) // If the scene is not the boss battle scene, then load the scene
                SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }
    }
}
