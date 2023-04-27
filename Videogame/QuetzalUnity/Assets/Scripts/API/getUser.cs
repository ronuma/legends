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
public class Slot
{
    public int session_id;
    public int hero_id;
    public int damage;
    public int health;
    public int mana;
    public float speed;
    public int defense;
    public string play_time;
    public int finished;
}

// Modify the User class to reflect the new structure of the data
[System.Serializable]
public class User
{
    public string email;
    public string user_name;
    public int runs;
    public Slot slot_1;
    public Slot slot_2; // Slot 2 and 3 are now objects instead of ints
    public Slot slot_3;
}

// Allow the class to be extracted from Unity
[System.Serializable]
public class UserList
{
    public List<User> users; // The API returns an array of users
}

public class getUser : MonoBehaviour
{
    string url = "https://quetzal-api.glitch.me"; // The URL of the API
    string getUsersEP = "/users/user1@example.com"; // The endpoint to get the users
    [SerializeField] Text errorText;

    // This is where the information from the api will be extracted
    public User uniqueUser;

    // Update is called once per frame

    // These are the functions that must be called to interact with the API

    void Start()
    {
        QueryUser();
    }

    public void QueryUser()
    {
        StartCoroutine(GetUser()); // async call to the API
    }


    // Test function to get a response and act accordingly
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    IEnumerator GetUser() // Async function to get the users from the API
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP)) // UNITY class request for API (UnityWebRequest)
        {
            yield return www.SendWebRequest(); // Await for the response

            if (www.result == UnityWebRequest.Result.Success) // If the response is successful
            {
                // Debug.Log("Response: " + www.downloadHandler.text); // The response is in the downloadHandler
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = www.downloadHandler.text; // add {} to make it an object
                uniqueUser = JsonUtility.FromJson<User>(jsonString);
                DisplayUser();
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
    IEnumerator GetUserString(System.Action<string> callback)
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
    // via another script that fills a scrollview
    void DisplayUser()
    {
        //TMPro_Test texter = GetComponent<TMPro_Test>();
        //texter.LoadNames(allItems)
        Debug.Log(uniqueUser);
        // Debug.Log(uniqueUser.slot_1.health);
        // Debug.Log(uniqueUser.slot_2.hero_id);
        // Debug.Log(allItems.items[4].name);
        Debug.Log("User loaded");
    }

}
