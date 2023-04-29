using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchRequest : MonoBehaviour
{
    public string apiUrl = "https://quetzal-api.glitch.me/users/endGame";
    public string jsonPayload = "{\"session_id\": INSERTARVALORGABIPORFAVOR}"; // The JSON payload you want to send
    // TODO: pasar el session_id de la sesion actual
    // TODO: lograr que este script sea ejecutado al desaparecer el boss
    IEnumerator Start()
    {
        var request = UnityWebRequest.Put(apiUrl, jsonPayload);
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
}