using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharacterType
{
    PLAYER,
    ENEMY
}
[CreateAssetMenu(fileName ="New Character Config", menuName ="Character Config")]
public class CharacterConfig : ScriptableObject
{
    public string title;
    public int hp;
    public int movementSpeed;
    public CharacterType type;
}
