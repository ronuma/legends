using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]

public class ClearSlotObject
{
    public int session_id;
}

public class ClearSlot : MonoBehaviour
{
    private string createUserEP = "/users/clearSlot";
    private string url = "https://quetzal-api.glitch.me";

    public int session_id_API;

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

        string jsonString = JsonUtility.ToJson(slot);

        using (UnityWebRequest www = UnityWebRequest.Put(url + createUserEP, jsonString))
        {
            www.method = "PATCH";
            www.SetRequestHeader("Content-Type", "application/json");
            Debug.Log("ClearSlot: " + jsonString);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
                yield break;
            }
            else
            {
                Debug.Log("ClearSlot: Form upload complete!");
            }
        }
    }
}