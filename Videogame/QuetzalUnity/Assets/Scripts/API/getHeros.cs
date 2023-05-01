/*
Test for the connection to an API
Able to use the Get method to read data and "Post" to send data
NOTE: Using Put instead of Post. See the links around line 86

Gilberto Echeverria
2023-04-12
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


// Create classes that correspond to the data that will be sent/received
// via the API

// Allow the class to be extracted from Unity
// https://stackoverflow.com/questions/40633388/show-members-of-a-class-in-unity3d-inspector
[System.Serializable]
public class Hero // Same object as in the API (JSON) response
{
    public int id;
    public string hero_name;
    public float health;
    public float mana;
    public float damage;
    public float defense;
    public float speed;
}

// Allow the class to be extracted from Unity
[System.Serializable]
public class HeroList
{
    public List<Hero> heros; // The API returns an array of users
}

public class getHeros : MonoBehaviour
{
    
    string url = "https://quetzal-api.glitch.me"; // The URL of the API
    string getUsersEP = "/characters/heroes"; // The endpoint to get the users
    [SerializeField] Text errorText;

    // This is where the information from the api will be extracted
    public HeroList allHeros;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space)) {
            QueryUsers(); // To get the data from the API on spacebar press
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            InsertNewUser();
        }
        */
    }

    // These are the functions that must be called to interact with the API

    public void QueryHeros()
    {
        StartCoroutine(GetHeros()); // async call to the API
    }


    // Test function to get a response and act accordingly
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    IEnumerator GetHeros() // Async function to get the users from the API
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP)) // UNITY class request for API (UnityWebRequest)
        {
            yield return www.SendWebRequest(); // Await for the response

            if (www.result == UnityWebRequest.Result.Success) // If the response is successful
            {
                // Debug.Log("Response: " + www.downloadHandler.text); // The response is in the downloadHandler
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{\"heros\":" + www.downloadHandler.text + "}"; // add {} to make it an object
                allHeros = JsonUtility.FromJson<HeroList>(jsonString);
                if (errorText != null) errorText.text = "";
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    // Sending the data back to the caller of the Coroutine, using a callback
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html
    IEnumerator GetItemsString(System.Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{\"users\":" + www.downloadHandler.text + "}";
                callback(jsonString);
                if (errorText != null) errorText.text = "";
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    // Show the results of the Query in the Unity UI elements,
    // via another script that fills a scrollvie
}
