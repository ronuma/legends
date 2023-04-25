using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUnlocker : MonoBehaviour
{
    private GameObject player;
    public GameObject dungeonGenerator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector3(-20, 0, 0);
            if (dungeonGenerator.GetComponent<DungeonGenerator>().dungeonLevel >= 5f)
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
                PlayerPrefs.SetInt("BOSSOpen", 1);
            }
        }
    }
}
