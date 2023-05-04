/* This script calls the API to end a session identified by the session_id and 
add a run to the registered email
*/
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private string apiUrl = "https://quetzal-api.glitch.me/users/endSession";
    public int sessionId;
    public bool bossIsDead = false;
    public bool bossDone = false;
    public GameObject player;

    void Start()
    {
        player = GetComponent<bossManager>().player;
        Debug.Log(player);
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
        if (bossIsDead && !bossDone)
        {
            StartCoroutine(FinishGame());
            bossDone = true;
        }
    }
}