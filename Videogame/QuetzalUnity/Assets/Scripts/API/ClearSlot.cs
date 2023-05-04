using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]

public class ClearSlotObject
{
    public int session_id; // this attributs are going to be contruscted into a json
}

public class ClearSlot : MonoBehaviour
{
    private string createUserEP = "/users/clearSlot"; // The endpoint to create a new user
    private string url = "https://quetzal-api.glitch.me"; // The URL of the API

    public int session_id_API; // the session_id to be cleared

    public void clearSlot(int session_id) 
    {
        session_id_API = session_id; 

        Corout();
    }

    private void Corout()
    {
        StartCoroutine(PatchReq()); 
    }

    IEnumerator PatchReq()
    {
        // Create a User object with the provided email, hero_id and memory_slot
        ClearSlotObject slot = new ClearSlotObject();
        slot.session_id = session_id_API;

        // Convert the User object into a JSON string
        string jsonString = JsonUtility.ToJson(slot);

        // Send the JSON string to the API via a POST request
        using (UnityWebRequest www = UnityWebRequest.Put(url + createUserEP, jsonString))
        {
            www.method = "PATCH";
            www.SetRequestHeader("Content-Type", "application/json");
            Debug.Log("ClearSlot: " + jsonString);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error); // Error
                yield break;
            }
            else
            {
                Debug.Log("ClearSlot: Form upload complete!");
            }
        }
    }
}