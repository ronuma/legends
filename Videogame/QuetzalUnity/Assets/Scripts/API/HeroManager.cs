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

        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Characters/" + character.characterName + ".prefab");
        GameObject playerOG = Instantiate(heros[currentIndex]);

        playerOG.GetComponent<PlayerStats>().playerHealth = GetComponent<getHeros>().allHeros.heros[currentIndex].health;
        playerOG.GetComponent<PlayerStats>().playerMana = GetComponent<getHeros>().allHeros.heros[currentIndex].mana;
        playerOG.GetComponent<PlayerStats>().playerDamage = GetComponent<getHeros>().allHeros.heros[currentIndex].damage;
        playerOG.GetComponent<PlayerStats>().playerDefense = GetComponent<getHeros>().allHeros.heros[currentIndex].defense;
        playerOG.GetComponent<PlayerStats>().playerSpeed = GetComponent<getHeros>().allHeros.heros[currentIndex].speed;
        playerOG.GetComponent<PlayerStats>().playerSession_id = sessionId;

        PrefabUtility.SaveAsPrefabAssetAndConnect(playerOG, "Assets/Prefabs/Characters/" + character.characterName + ".prefab", InteractionMode.UserAction);
    }
}
