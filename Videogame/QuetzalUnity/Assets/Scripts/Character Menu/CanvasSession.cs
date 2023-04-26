using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSession : MonoBehaviour
{
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
        slots = new int[3] { 0, 1, 2};
    }

    void Upload()
    {
        UpdateCharacter(slots[0], characterSprite1, characterName1);
        UpdateCharacter(slots[1], characterSprite2, characterName2);
        UpdateCharacter(slots[2], characterSprite3, characterName3);
    }

    private void UpdateCharacter(int index, Image characterSpriteStatic, TMPro.TextMeshProUGUI characterNameStatic)
    {
        Characters character = characterData.GetCharacter(index);
        characterSpriteStatic.sprite = character.characterSprite;
        characterNameStatic.text = character.characterName;
    }
}