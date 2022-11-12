using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Skins", menuName = "ScriptableObjects/Skins", order = 1)]
public class Skins : ScriptableObject
{
    [SerializeField] Material[] SkinBodyColor;

    private int amount;

    public int Amount { get => SkinBodyColor.Length; }

    public Material GetSkinColor(ColorType colorType)
    {
        return SkinBodyColor[(int)colorType];
    }
}
