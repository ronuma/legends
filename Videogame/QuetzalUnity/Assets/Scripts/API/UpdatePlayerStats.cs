using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerStats : MonoBehaviour
{
    public string apiUrl = "http://localhost:8000/users/updateStats";
    // public string reqBody = "{\"session_id\": \"27\",\"health\": \"50\",\"mana\": \"5\",\"defense\": \"42\",\"speed\": \"2\",\"damage\": \"10\"}"; // The JSON payload you want to send

    IEnumerator Start()
    {
        // si no se la pongo aquí directo no me jala, no se por qué
        var request = UnityWebRequest.Put(apiUrl, "{\"session_id\": 27,\"health\": 50,\"mana\": 5,\"defense\": 42,\"speed\": 2,\"damage\": 5}");
        request.method = "PATCH";
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string responseText = request.downloadHandler.text;
            Debug.Log("Server response: " + responseText);
        }
    }
}
