using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterData characterData;
    public Image characterSprite;
    public TMPro.TextMeshProUGUI characterName;
    public TMPro.TextMeshProUGUI characterDescription;

    public GameObject createNewPlayer;
    public GameObject mainPageManager;
    public int slotID;

    public GameObject characterPrefab;

    private int currentCharacterIndex = 0;

    void Start()
    {
        UpdateCharacter(currentCharacterIndex);
    }

    public void NextCharacter()
    {
        currentCharacterIndex++;
        if (currentCharacterIndex >= characterData.characterCount)
        {
            currentCharacterIndex = 0;
        }
        UpdateCharacter(currentCharacterIndex);
    }

    public void PreviousCharacter()
    {
        currentCharacterIndex--;
        if (currentCharacterIndex < 0)
        {
            currentCharacterIndex = characterData.characterCount - 1;
        }
        UpdateCharacter(currentCharacterIndex);
    }

    public void ChooseCharacter()
    {
        PlayerPrefs.SetInt("playerChosen", currentCharacterIndex);
        PlayerPrefs.Save();

        createNewPlayer.GetComponent<CreateNewPlayer>().memory_slot = slotID;
        createNewPlayer.GetComponent<CreateNewPlayer>().hero_id = currentCharacterIndex + 1;
        createNewPlayer.GetComponent<CreateNewPlayer>().CreateSession();
       // int sesID = createNewPlayer.GetComponent<CreateNewPlayer>().sesion_id;

        //mainPageManager.GetComponent<HeroManager>().CreatePlayer(sesID);

      //  Debug.Log("Player Chosen: " + currentCharacterIndex);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    private void UpdateCharacter(int index)
    {
        Characters character = characterData.GetCharacter(index);
        characterSprite.sprite = character.characterSprite;
        characterName.text = character.characterName;
        characterDescription.text = character.characterDescription;
    }
}