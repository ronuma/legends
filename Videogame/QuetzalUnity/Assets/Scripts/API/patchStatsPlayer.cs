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
public class User // Same object as in the API (JSON) response
{
    public int session_id = 1;
    public float health = 2;
    public float mana = 3;
    public float damage = 4;
    public float speed = 5;
    public float defense = 6;
}



// Allow the class to be extracted from Unity
[System.Serializable]
public class UserList
{
    public List<User> users; // The API returns an array of users
}

public class patchStatsPlayer : MonoBehaviour
{
    [SerializeField] string url; // The URL of the API
    [SerializeField] string getUsersEP; // The endpoint to get the users
    [SerializeField] Text errorText;

    // This is where the information from the api will be extracted
    public UserList allUsers;


    void Start()
    {
        Debug.Log("Im running Users");
    }
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


    public void InsertNewUser()
    {
        StartCoroutine(AddUser());
    }

    // Test function to get a response and act accordingly
    // // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html
    public void GetResults()
    {
        UserList localUsers;
        // Call the IEnumerator and pass a lambda function to be called
        StartCoroutine(GetUsersString((reply) =>
        {
            localUsers = JsonUtility.FromJson<UserList>(reply);
            DisplayUsers();
        }));
    }

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    IEnumerator AddUser()
    {
        /*
        // This should work with an API that does NOT expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        User testUser = new User();
        //GetComponent<ManagerStatsPlayer>().UpdateStats();
        // testUser.name = "newGuy" + Random.Range(1000, 9000).ToString();
        // testUser.surname = "Tester" + Random.Range(1000, 9000).ToString();
        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testUser);
        //Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + getUsersEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "PUT";
            www.SetRequestHeader("Content-Type", "application/json");
            //www.SetRequestHeader("Authorization", "Bearer saoifnapoeinra");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + www.downloadHandler.text);
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
    IEnumerator GetUsersString(System.Action<string> callback)
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
    void DisplayUsers()
    {
        Debug.Log("Users loaded");
        Debug.Log(allUsers.users.Count);
    }

}