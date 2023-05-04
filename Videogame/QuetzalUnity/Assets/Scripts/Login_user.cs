/* This script logs in a user by sending a GET request to the API. The user
inputs their email address in a TMP_InputField, and the script fetches user data
from the server based on the provided email. If the server returns a valid
response, the user's email is stored in PlayerPrefs and the scene with index 1
(the overworld) is loaded.

This script is attached to the Login/Register scene and is called by the Login
button.

Authored by: Enrique C. Last modified on: 01/05/2023 by Gabriel R. for final
integration.
*/
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class Login_user : MonoBehaviour
{
    public TMP_InputField emailInputField; // Reference to the email input field
    public TMP_Text responseText; // Reference to the response text

    public void Send_GETRequest()
    {
        string email = emailInputField.text; // Get the email from the input field
        StartCoroutine(GetRequest(email));
    }

    IEnumerator GetRequest(string email) // Async function to get the users from the API
    {
        string url = "https://quetzal-api.glitch.me/users/" + email;

        if (email == null || email == "") // If the email is empty, return
        {
            yield break;
        }

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        // UNITY class request for API (UnityWebRequest)
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Received: " + webRequest.downloadHandler.text);
                PlayerPrefs.SetString("emailUser", email);
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
        }
    }
}
