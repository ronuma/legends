using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    // Reference to the character data asset
    public CharacterData characterData;

    // Reference to the UI image element that displays the character sprite
    public Image characterSprite;

    // Reference to the UI text element that displays the character name
    public TMPro.TextMeshProUGUI characterName;

    // Reference to the UI text element that displays the character description
    public TMPro.TextMeshProUGUI characterDescription;

    // Reference to the "Create New Player" game object
    public GameObject createNewPlayer;

    // Reference to the "Main Page Manager" game object
    public GameObject mainPageManager;

    // The index of the slot where the new player will be saved
    public int slotID;

    // The session ID of the newly created player character
    private int sesID;

    // Reference to the game object that represents the character in the game world
    public GameObject characterPrefab;

    // Index of the currently selected character
    private int currentCharacterIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Update the displayed character information with the first character in the list
        UpdateCharacter(currentCharacterIndex);
    }

    // Switch to the next character in the list
    public void NextCharacter()
    {
        currentCharacterIndex++;

        // If the index is greater than the number of characters, wrap around to the first character
        if (currentCharacterIndex >= characterData.characterCount)
        {
            currentCharacterIndex = 0;
        }

        // Update the displayed character information
        UpdateCharacter(currentCharacterIndex);
    }

    // Switch to the previous character in the list
    public void PreviousCharacter()
    {
        currentCharacterIndex--;

        // If the index is less than zero, wrap around to the last character
        if (currentCharacterIndex < 0)
        {
            currentCharacterIndex = characterData.characterCount - 1;
        }

        // Update the displayed character information
        UpdateCharacter(currentCharacterIndex);
    }

    // Choose the currently selected character and create a new player character
    public void ChooseCharacter()
    {
        // Set the chosen character index in player preferences
        PlayerPrefs.SetInt("playerChosen", currentCharacterIndex);
        PlayerPrefs.Save();

        // Pass additional information to the "CreateNewPlayer" object
        createNewPlayer.GetComponent<CreateNewPlayer>().memory_slot = slotID;
        createNewPlayer.GetComponent<CreateNewPlayer>().hero_id = currentCharacterIndex + 1;

        // Create a new player character and switch to the game scene
        createNewPlayer.GetComponent<CreateNewPlayer>().CreateSession();
        StartCoroutine(heroBuilder());
    }

    // Coroutine that waits for the new player character to be created and then switches to the game scene
    IEnumerator heroBuilder()
    {
        // Wait for a short time
        yield return new WaitForSeconds(0.5f);

        // Get the session ID of the newly created player character
        sesID = createNewPlayer.GetComponent<CreateNewPlayer>().sesion_id;

        // Create the player character in the game world using the "HeroManager" object
        mainPageManager.GetComponent<HeroManager>().CreatePlayer(sesID, currentCharacterIndex);

        // Wait for another short time
        yield return new WaitForSeconds(2f);

        // Switch to the game scene
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    private void UpdateCharacter(int index)
    {
        Characters character = characterData.GetCharacter(index);
        characterSprite.sprite = character.characterSprite;
        characterName.text = character.characterName;
        characterDescription.text = character.characterDescription;
    }
}