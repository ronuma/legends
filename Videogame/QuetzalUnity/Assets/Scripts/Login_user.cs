using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class Login_user : MonoBehaviour {

    public TMP_InputField emailInputField;
    public TMP_Text responseText;

    public void Send_GETRequest() {
        string email = emailInputField.text;
        StartCoroutine(GetRequest(email));
    }

    IEnumerator GetRequest(string email) {
        string url = "https://quetzal-api.glitch.me/users/" + email;

        if (email == "") {
            responseText.text = "Please fill out all fields.";
            yield break;
        }

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)) {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) {
                Debug.LogError("Error: " + webRequest.error);
            } else {
                Debug.Log("Received: " + webRequest.downloadHandler.text);
                PlayerPrefs.SetString("emailUser", email);
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
        }
    }
}
