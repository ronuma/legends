using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class UpdateUser
{
    public float health;
    public float mana;
    public float defense;
    public float damage;
    public float speed;
    public int session_id;
    public int item_id;
}

public class UpdatePlayerStats : MonoBehaviour
{
    private string createUserEP = "/users/selectItem";
    private string url = "https://quetzal-api.glitch.me";

    public float health_API;
    public float mana_API;
    public float defense_API;
    public float damage_API;
    public float speed_API;
    public int session_id_API;
    public int item_id_API;


    public void createStats(float health, float mana, float defense, 
                            float damage, float speed, int session_id, 
                            int item_id)
    {
        health_API = health;
        mana_API = mana;
        defense_API = defense;
        damage_API = damage;
        speed_API = speed;
        session_id_API = session_id;
        item_id_API = item_id;

        CreateSession();
    }

    private void CreateSession()
    {
        StartCoroutine(PostRequest());
    }

    IEnumerator PostRequest()
    {
        // Create a User object with the provided email, hero_id and memory_slot
        UpdateUser newuser = new UpdateUser();
        newuser.health = health_API;
        newuser.mana = mana_API;
        newuser.defense = defense_API;
        newuser.damage = damage_API;
        newuser.speed = speed_API;
        newuser.session_id = session_id_API;
        newuser.item_id = item_id_API;

        // Serialize the User object to a JSON string
        string jsonString = JsonUtility.ToJson(newuser);

        using (UnityWebRequest www = UnityWebRequest.Put(url + createUserEP, jsonString))
        { 
            www.method = "PATCH";
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
                yield break;
            }

            // Deserialize the JSON response into a User object
            UpdateUser newUser2 = JsonUtility.FromJson<UpdateUser>(www.downloadHandler.text);
        }
    }
}

