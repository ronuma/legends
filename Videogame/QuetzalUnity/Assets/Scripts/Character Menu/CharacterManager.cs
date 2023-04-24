using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterData characterData;
    public SpriteRenderer characterSprite;
    public TMPro.TextMeshProUGUI characterName;
    public TMPro.TextMeshProUGUI characterDescription;

    private int currentCharacterIndex = 0;

    void Start()
    {
        UpdateCharacter(currentCharacterIndex);
    }

    public void NextCharacter()
    {
        Debug.Log("Next Character");
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

    private void UpdateCharacter(int index)
    {
        Characters character = characterData.GetCharacter(index);
        characterSprite.sprite = character.characterSprite; 
        characterName.text = character.characterName;
        characterDescription.text = character.characterDescription;
    }
}