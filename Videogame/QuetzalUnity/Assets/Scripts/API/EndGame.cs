using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private string apiUrl = "https://quetzal-api.glitch.me/users/endSession";
    public int sessionId;
    public bool bossIsDead = false;
    public GameObject player;
    // TODO: pasar el session_id de la sesion actual
    // TODO: lograr que este script sea ejecutado al desaparecer el boss

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sessionId = player.GetComponent<PlayerStats>().playerSession_id;
    }

    IEnumerator FinishGame()
    {
        var request = UnityWebRequest.Put(apiUrl, "{\"session_id\": " + sessionId +"}");
        request.method = "PATCH"; 
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log("Finished session");
        }
    }

    void Update()
    {
        if (bossIsDead)
        {
            StartCoroutine(FinishGame());
        }
    }
}