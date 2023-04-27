using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasSession : MonoBehaviour
{
    //Canvases that are involved in the character selection
    public Canvas menu;
    public GameObject characterManager;
    public Canvas session;

    //Prefabs of the characters
    public GameObject playerPrefabBow;
    public GameObject playerPrefabSword;
    public GameObject playerPrefabSpear;

    public GameObject[] playerPrefabs;

    //APIs that are involved in the character selection
    public GameObject getUser;
    public GameObject createNewPlayer;

    //Character data for sprites and names
    public CharacterData characterData;
    public Slot[] slots;

    //Component of the canvas that will be updated
    public Image characterSprite1;
    public TMPro.TextMeshProUGUI characterName1;

    public Image characterSprite2;
    public TMPro.TextMeshProUGUI characterName2;

    public Image characterSprite3;
    public TMPro.TextMeshProUGUI characterName3;

    void Start()
    {
        playerPrefabs = new GameObject[] {playerPrefabSpear, playerPrefabBow, playerPrefabSword};
        StartCoroutine(processUserData());
    }

    IEnumerator processUserData()
    {
        yield return new WaitForSeconds(2f);

        slots = new Slot[3] { getUser.GetComponent<getUser>().uniqueUser.slot_1, getUser.GetComponent<getUser>().uniqueUser.slot_2, getUser.GetComponent<getUser>().uniqueUser.slot_3};

        UpdateCharacter(slots[0], characterSprite1, characterName1);
        UpdateCharacter(slots[1], characterSprite2, characterName2);
        UpdateCharacter(slots[2], characterSprite3, characterName3);
    }

    private void UpdateCharacter(Slot index, Image characterSpriteStatic, TMPro.TextMeshProUGUI characterNameStatic)
    {
        int playerId = index.hero_id > 0 ? index.hero_id-1 : -1;
       
        if (playerId >= 0)
        {
            Characters character = characterData.GetCharacter(playerId);
            characterSpriteStatic.sprite = character.characterSprite;
            characterNameStatic.text = character.characterName;
        }
    }

    public void leftClick()
    {
        ChooseCharacter(slots[0], 1);
    }

    public void rightClick()
    {
        ChooseCharacter(slots[2], 3);
    }

    public void middleClick()
    {
        ChooseCharacter(slots[1], 2);
    }

    public void ChooseCharacter(Slot index, int slot)
    {
        int playerId = index.hero_id > 0 ? index.hero_id-1 : -1;

        if (playerId >= 0)
        {
        ModifyPlayerStats(playerId, index);
        PlayerPrefs.SetInt("playerChosen", playerId);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else
        {
            session.enabled = false;
            menu.enabled = true;
            characterManager.GetComponent<CharacterManager>().slotID = slot;
        }
    }

    void ModifyPlayerStats(int playerId, Slot index)
    {
        playerPrefabs[playerId].GetComponent<PlayerStats>().playerDamage = index.damage;
        playerPrefabs[playerId].GetComponent<PlayerStats>().playerHealth = index.health;
        playerPrefabs[playerId].GetComponent<PlayerStats>().playerMana = index.mana;
        playerPrefabs[playerId].GetComponent<PlayerStats>().playerSpeed = index.speed;
        playerPrefabs[playerId].GetComponent<PlayerStats>().playerDefense = index.defense;
        playerPrefabs[playerId].GetComponent<PlayerStats>().playerSession_id = index.session_id;
    }

}