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
        Time.timeScale = 1;
    }

    void Update()
    {
        bossBattleOpen = PlayerPrefs.GetInt("BOSSOpen", 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (sceneIndex == 4 && bossBattleOpen == 1)
            {
                SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
            }

            if (sceneIndex != 3)
                SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }
    }
}
