using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasSession : MonoBehaviour
{
    public Canvas menu;
    public Canvas session;

    public GameObject getUser;
    public GameObject createNewPlayer;

    public CharacterData characterData;
    public int[] slots;
    
    public Image characterSprite1;
    public TMPro.TextMeshProUGUI characterName1;

    public Image characterSprite2;
    public TMPro.TextMeshProUGUI characterName2;

    public Image characterSprite3;
    public TMPro.TextMeshProUGUI characterName3;

    void Start()
    {
        StartCoroutine(processUserData());
    }

    IEnumerator processUserData()
    {
        yield return new WaitForSeconds(2f);
        int playerId1 = getUser.GetComponent<getUser>().uniqueUser.slot_1.hero_id > 0 ? getUser.GetComponent<getUser>().uniqueUser.slot_1.hero_id-1 : -1;
        int playerId2 = getUser.GetComponent<getUser>().uniqueUser.slot_2.hero_id > 0 ? getUser.GetComponent<getUser>().uniqueUser.slot_2.hero_id-1 : -1;
        int playerId3 = getUser.GetComponent<getUser>().uniqueUser.slot_3.hero_id > 0 ? getUser.GetComponent<getUser>().uniqueUser.slot_3.hero_id-1 : -1;

        slots = new int[3] { playerId1, playerId2, playerId3};

        UpdateCharacter(slots[0], characterSprite1, characterName1);
        UpdateCharacter(slots[1], characterSprite2, characterName2);
        UpdateCharacter(slots[2], characterSprite3, characterName3);
    }

    private void UpdateCharacter(int index, Image characterSpriteStatic, TMPro.TextMeshProUGUI characterNameStatic)
    {
        if (index >= 0)
        {
            Characters character = characterData.GetCharacter(index);
            characterSpriteStatic.sprite = character.characterSprite;
            characterNameStatic.text = character.characterName;
        }
    }

    public void leftClick()
    {
        ChooseCharacter(slots[0]);
    }

    public void rightClick()
    {
        ChooseCharacter(slots[2]);
    }

    public void middleClick()
    {
        ChooseCharacter(slots[1]);
        createNewPlayer.GetComponent<CreateNewPlayer>().CreateSession();
    }

    private void ChooseCharacter(int index)
    {
        if (index >= 0)
        {
        PlayerPrefs.SetInt("playerChosen", index);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else
        {
            session.enabled = false;
            menu.enabled = true;
        }
    }

}