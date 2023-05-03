using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSSHealth : MonoBehaviour
{
    public Canvas credits;
    public bool isTransformed = false;
    public float enemyHealth;
    public float maxHealth;
    public GameObject gameManager;
    public Animator animator; // A reference to the animator component // A flag for indicating if the player can transform
    private float durationTimer; // A timer for the duration of the transformation

    // Start is called before the first frame update
    void Start()
    {   
        credits = GameObject.Find("CanvasCredits").GetComponent<Canvas>();
        maxHealth = GetComponent<BossStats>().enemyHealth;
        enemyHealth = maxHealth;
        gameManager = GameObject.Find("EndgameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= maxHealth / 2 && !isTransformed)
        {
            Debug.Log("transform");
            isTransformed = true;
            animator.SetBool("FinalForm", true); // Set the animation trigge
            GetComponent<BossStats>().enemyDamage = GetComponent<BossStats>().enemyDamage * 2;
        }

        if (enemyHealth <= 0)
        {
            gameManager.GetComponent<EndGame>().bossIsDead = true;
            credits.enabled = true;
            
        }        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        Destroy(gameObject);
    }
}   