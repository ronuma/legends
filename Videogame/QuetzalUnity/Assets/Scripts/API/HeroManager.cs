using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HeroManager : MonoBehaviour
{
    public GameObject[] heros;
    public CharacterData characterData;

    public int sessionId;
    public int currentIndex;

    // Start is called before the first frame update
    public void CreatePlayer(int ses, int index)
    {
        sessionId = ses;
        currentIndex = index;
        GetComponent<getHeros>().QueryHeros();
        StartCoroutine(Starthero());
    }

    private IEnumerator Starthero()
    {
        yield return new WaitForSeconds(1f);
        Characters character = characterData.GetCharacter(currentIndex);

        GameObject prefab = Resources.Load<GameObject>("Characters/" + character.characterName);

        prefab.GetComponent<PlayerStats>().playerHealth = GetComponent<getHeros>().allHeros.heros[currentIndex].health;
        prefab.GetComponent<PlayerStats>().playerMana = GetComponent<getHeros>().allHeros.heros[currentIndex].mana;
        prefab.GetComponent<PlayerStats>().playerDamage = GetComponent<getHeros>().allHeros.heros[currentIndex].damage;
        prefab.GetComponent<PlayerStats>().playerDefense = GetComponent<getHeros>().allHeros.heros[currentIndex].defense;
        prefab.GetComponent<PlayerStats>().playerSpeed = GetComponent<getHeros>().allHeros.heros[currentIndex].speed;
        prefab.GetComponent<PlayerStats>().playerSession_id = sessionId;

        // PrefabUtility.SaveAsPrefabAssetAndConnect(playerOG, "Assets/Prefabs/Characters/" + character.characterName + ".prefab", InteractionMode.UserAction);
    }
}
