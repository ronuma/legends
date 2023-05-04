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

public class bossManager : MonoBehaviour
{
    public Canvas credits;
    public Animator animator;
    public bool bossIsDead = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        credits.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossIsDead)
        {
            credits.enabled = true;
            animator.SetTrigger("Credits");
            StartCoroutine(Wait());
        }   
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(14.5f);
        SceneManager.LoadScene(2, LoadSceneMode.Single); 
    }
}
