using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    readonly public float defaultSpeed = 5;
    readonly public float defaultRangeAttack = 6;

    public float speed;

    public float RangeAttack;
    
}
