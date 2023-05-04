using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // attribute that allows the object to be created from the Unity Editor
public class CharacterData : ScriptableObject // a scriptable object that contains data about characters
{
    public Characters[] character; // an array that holds the data of Characters, with each element representing a single character

    public int characterCount // a property that returns the length of the character array
    {   
        get
        {
            return character.Length;
        }
    }

    public Characters GetCharacter(int i) // a method that returns the character at the given index of the character array
    {
        return character[i];
    }
}
