/* This script manages the behavior and events related to the boss in the game.
When the boss is defeated, it displays the credits and plays the credits animation.
After a specified delay, the scene transitions to a new scene. 

Written by: Gabriel Rodriguez
Last modified by Pablo Banzo: 02/05/2023 (changes for correct scene loading for webGL) 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script is in charge of managinf the boss fight and all the events related to it

public class bossManager : MonoBehaviour
{
    public Canvas credits; // the credits canvas
    public Animator animator; // the animator of the credits
    public bool bossIsDead = false; // the boss is dead
    public GameObject player; // the player

    // Start is called before the first frame update
    void Start()
    {
        credits.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player"); // get the player
        Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossIsDead) // if the boss is dead
        {
            credits.enabled = true; // enable the credits
            animator.SetTrigger("Credits"); // play the credits animation
            StartCoroutine(Wait());
        }   
    }

    IEnumerator Wait()
    // this function waits for the credits to finish and then loads the next scene
    {
        yield return new WaitForSeconds(14.5f);
        SceneManager.LoadScene(2, LoadSceneMode.Single); 
    }
}
