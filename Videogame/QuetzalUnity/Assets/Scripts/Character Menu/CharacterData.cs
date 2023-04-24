using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public Characters[] character;

    public int characterCount
    {   
        get
        {
            return character.Length;
        }
    }

    public Characters GetCharacter(int i)
    {
        return character[i];
    }
}
