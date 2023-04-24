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
public class Item // Same object as in the API (JSON) response
{
    public int item_id;
    public string name;
    public float damage_change;
    public float defense_change;
    public float health_change;
    public float mana_change;
    public float speed_change;
    public int times_chosen;
}

// Allow the class to be extracted from Unity
[System.Serializable]
public class ItemList
{
    public List<Item> items; // The API returns an array of users
}

public class getItems : MonoBehaviour
{
    [SerializeField] string url; // The URL of the API
    [SerializeField] string getUsersEP; // The endpoint to get the users
    [SerializeField] Text errorText;

    // This is where the information from the api will be extracted
    public ItemList allItems;

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

    void Start()
    {
        QueryItems();
    }

    public void QueryItems()
    {
        StartCoroutine(GetItems()); // async call to the API
    }


    // Test function to get a response and act accordingly
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    IEnumerator GetItems() // Async function to get the users from the API
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP)) // UNITY class request for API (UnityWebRequest)
        {
            yield return www.SendWebRequest(); // Await for the response

            if (www.result == UnityWebRequest.Result.Success) // If the response is successful
            {
                // Debug.Log("Response: " + www.downloadHandler.text); // The response is in the downloadHandler
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{\"items\":" + www.downloadHandler.text + "}"; // add {} to make it an object
                allItems = JsonUtility.FromJson<ItemList>(jsonString);
                DisplayItems();
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
    // via another script that fills a scrollview
    void DisplayItems()
    {
        //TMPro_Test texter = GetComponent<TMPro_Test>();
        //texter.LoadNames(allItems);
        Debug.Log(allItems.items.Count);
        // Debug.Log(allItems.items[0].health_change);
        // Debug.Log(allItems.items[4].name);
        Debug.Log("Items loaded");
    }

}
