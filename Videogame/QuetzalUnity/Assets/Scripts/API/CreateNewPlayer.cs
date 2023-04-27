using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class NewUser
{
    public string email;
    public int hero_id;
    public int memory_slot;
}

public class CreateNewPlayer : MonoBehaviour
{
    private string createUserEP = "/users/createSession";
    private string url = "https://quetzal-api.glitch.me";
    public string email = "user1@example.com";
    public int hero_id;
    public int memory_slot;

    public void CreateSession()
    {
        StartCoroutine(PostRequest());
    }

    IEnumerator PostRequest()
    {
        // Create a User object with the provided email, hero_id and memory_slot
        NewUser newuser = new NewUser();
        newuser.email = email;
        newuser.hero_id = hero_id;
        newuser.memory_slot = memory_slot;

        // Serialize the User object to a JSON string
        string jsonString = JsonUtility.ToJson(newuser);

        using (UnityWebRequest www = UnityWebRequest.Put(url + createUserEP, jsonString))
        { 
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
                yield break;
            }

            // Deserialize the JSON response into a User object
            NewUser newUser2 = JsonUtility.FromJson<NewUser>(www.downloadHandler.text);
            Debug.Log("User created with email: " + newUser2.email);
        }
    }
}
