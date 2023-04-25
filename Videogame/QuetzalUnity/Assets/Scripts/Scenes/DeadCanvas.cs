using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadCanvas : MonoBehaviour
{
    public Canvas deadCanvas;
    public TMPro.TextMeshProUGUI deadCanvasText;

    private bool isDead = false;

    void Start()
    {
        deadCanvas.enabled = false;
    }

    void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    public void EnableDeadCanvas()
    {
        isDead = true;
        deadCanvas.enabled = true;
        Time.timeScale = 0;
    }

}