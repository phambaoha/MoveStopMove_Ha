using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pants", menuName = "ScriptableObjects/Pants", order = 2)]
public class Pants : ScriptableObject
{
    [SerializeField] Material[] PantsMat;

    private readonly int amout;

    public int Amount { get => PantsMat.Length; }

    public Material GetSkinPants(PantType pantType)
    {
        return PantsMat[(int)pantType];
    }
}

