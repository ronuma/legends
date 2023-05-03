using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class UserName
{
    public string email;
    public string user_name;
    public UserName(string email, string username) {
        this.email = email;
        this.user_name = username;
    }
}

public class Register_user : MonoBehaviour {

    public TMP_InputField emailInputField;
    public TMP_InputField usernameInputField;
    public TMP_Text responseText;

    public Canvas login;
    public Canvas register;

    public void Send_POSTRequest() {
        string email = emailInputField.text;
        string username = usernameInputField.text;
        StartCoroutine(PostRequest(email, username));
    }

    IEnumerator PostRequest(string email, string username) {
        string url = "https://quetzal-api.glitch.me/users/add";

        if (email == "" || username == "") {
            responseText.text = "Please fill out all fields.";
            yield break;
        }

        string json = JsonUtility.ToJson(new UserName(email, username));

        using (UnityWebRequest webRequest = UnityWebRequest.Put(url, json)) {
            webRequest.method = "POST";
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Accept", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) {
                Debug.LogError("Error: " + webRequest.error);
            } else {
                Debug.Log("Received: " + webRequest.downloadHandler.text);
            }
        }

        login.gameObject.SetActive(true);
        register.gameObject.SetActive(false);
    }


}
