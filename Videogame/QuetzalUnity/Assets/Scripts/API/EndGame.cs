using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script modifies the status of the session once the boss is dead
// it is attached to the bossManager object
public class EndGame : MonoBehaviour 
{
    private string apiUrl = "https://quetzal-api.glitch.me/users/endSession";
    public int sessionId; // the session_id of the game `
    public bool bossIsDead = false; // the boss is dead
    public bool bossDone = false; // bollean that prevents that the API is called more than once
    public GameObject player;
    // TODO: pasar el session_id de la sesion actual
    // TODO: lograr que este script sea ejecutado al desaparecer el boss

    void Start()
    {
        player = GetComponent<bossManager>().player; // get the player
        Debug.Log(player);
        sessionId = player.GetComponent<PlayerStats>().playerSession_id; // get the session_id from the player
    }

    IEnumerator FinishGame()
    {
        // Create a User object with the provided email, hero_id and memory_slot
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
        if (bossIsDead && !bossDone) // if the boss is dead and the API has not been called yet
        {
            StartCoroutine(FinishGame()); // call the API
            bossDone = true;
        }
    }
}