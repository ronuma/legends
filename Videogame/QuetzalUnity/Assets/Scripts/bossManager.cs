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
