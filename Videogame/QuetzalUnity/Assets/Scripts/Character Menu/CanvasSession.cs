using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CanvasSession : MonoBehaviour
{
    //Canvases that are involved in the character selection
    public Canvas menu;
    public GameObject characterManager;
    public Canvas session;

    // Kill btns
    public Button leftBtn;
    public Button rightBtn;
    public Button middleBtn;

    //Prefabs of the characters
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
        // default buttons to disabled
        leftBtn.GetComponent<Image>().enabled = false;
        rightBtn.GetComponent<Image>().enabled = false;
        middleBtn.GetComponent<Image>().enabled = false;
        // text blank
        leftBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";
        rightBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";
        middleBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";

        // Call processUserData() coroutine
        StartCoroutine(processUserData());
    }

    // Coroutine that processes user data
    IEnumerator processUserData()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Get user's slots data
        slots = new Slot[3] { getUser.GetComponent<getUser>().uniqueUser.slot_1, getUser.GetComponent<getUser>().uniqueUser.slot_2, getUser.GetComponent<getUser>().uniqueUser.slot_3 };

        // Update the character slots on the canvas
        UpdateCharacter(slots[0], characterSprite1, characterName1, leftBtn);
        UpdateCharacter(slots[1], characterSprite2, characterName2, middleBtn);
        UpdateCharacter(slots[2], characterSprite3, characterName3, rightBtn);
    }

    // Method to update the character on the canvas
    private void UpdateCharacter(Slot index, Image characterSpriteStatic, TMPro.TextMeshProUGUI characterNameStatic, Button btn)
    {
        // Get the player ID
        int playerId = index.hero_id > 0 ? index.hero_id - 1 : -1;

        if (playerId >= 0)
        {
            // Get the character data and update the character sprite and name
            Characters character = characterData.GetCharacter(playerId);
            characterSpriteStatic.sprite = character.characterSprite;
            characterNameStatic.text = character.characterName;

            // Enable the button by adding image and text
            btn.GetComponent<Image>().enabled = true;
            btn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "X";
        }
    }

    // Method that is called when the left button is clicked
    public void leftClick()
    {
        ChooseCharacter(slots[0], 1);
    }

    // Method that is called when the right button is clicked
    public void rightClick()
    {
        ChooseCharacter(slots[2], 3);
    }

    // Method that is called when the middle button is clicked
    public void middleClick()
    {
        ChooseCharacter(slots[1], 2);
    }

    public void killLeft()
    {
         
        Debug.Log("=====>" + slots[0].session_id);
         // Start a coroutine to call the API and clear the left slot
        StartCoroutine(DoAPI(slots[0].session_id));
    }

    public void killMiddle()
    {
        // Start a coroutine to call the API and clear the middle slot
        StartCoroutine(DoAPI(slots[1].session_id));
    }

    public void killRight()
    {
        // Start a coroutine to call the API and clear the right slot
        StartCoroutine(DoAPI(slots[2].session_id));
    }
    public void ChooseCharacter(Slot index, int slot)
    {
        // Get the player ID
        int playerId = index.hero_id > 0 ? index.hero_id - 1 : -1;
        Debug.Log("=====>" + playerId);

        if (playerId >= 0) // If the player ID is valid, modify stats
        {
            Debug.Log("INSIDEEEEE");
            StartCoroutine(ModifyPlayerStats(playerId, index));
        }
        else
        {
            // If the player ID is invalid, enable the character manager and disable the menu
            session.enabled = false;
            menu.enabled = true;
            characterManager.GetComponent<CharacterManager>().slotID = slot;
        }
    }

    IEnumerator ModifyPlayerStats(int playerId, Slot index)
    {
        yield return new WaitForSeconds(1f);
        Characters character = characterData.GetCharacter(playerId);

        // Get the player prefab

        GameObject prefab = Resources.Load<GameObject>("Characters/" + character.characterName);

        // Get the player OG prefab
        prefab.GetComponent<PlayerStats>().playerDamage = index.damage;
        prefab.GetComponent<PlayerStats>().playerHealth = index.health;
        prefab.GetComponent<PlayerStats>().playerMana = index.mana;
        prefab.GetComponent<PlayerStats>().playerSpeed = index.speed;
        prefab.GetComponent<PlayerStats>().playerDefense = index.defense;
        prefab.GetComponent<PlayerStats>().playerSession_id = index.session_id;

        //Now i wnt to save playerOG as the original prefab
        // PrefabUtility.SaveAsPrefabAssetAndConnect(playerOG, "Assets/Prefabs/Characters/" + character.characterName + ".prefab", InteractionMode.UserAction);

        PlayerPrefs.SetInt("playerChosen", playerId);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    IEnumerator DoAPI(int index) // index is the session_id
    {
        Debug.Log("=====>" + index);
        yield return new WaitForSeconds(1f);
        getUser.GetComponent<ClearSlot>().clearSlot(index);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}