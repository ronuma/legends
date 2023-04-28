using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public GameObject[] heros;

    public GameObject characterManager;

    public int sessionId;

    // Start is called before the first frame update
    public void CreatePlayer(int ses)
    {
        sessionId = ses;
        StartCoroutine(Starthero());
    }

    private IEnumerator Starthero()
    {
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < heros.Length; i++)
        {
            heros[i].GetComponent<PlayerStats>().playerHealth = GetComponent<getHeros>().allHeros.heros[i].health;
            heros[i].GetComponent<PlayerStats>().playerMana = GetComponent<getHeros>().allHeros.heros[i].mana;
            heros[i].GetComponent<PlayerStats>().playerDamage = GetComponent<getHeros>().allHeros.heros[i].damage;
            heros[i].GetComponent<PlayerStats>().playerDefense = GetComponent<getHeros>().allHeros.heros[i].defense;
            heros[i].GetComponent<PlayerStats>().playerSpeed = GetComponent<getHeros>().allHeros.heros[i].speed;
            heros[i].GetComponent<PlayerStats>().playerSession_id = sessionId;
        }
    }
}
