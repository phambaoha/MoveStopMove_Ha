using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Skins", menuName = "ScriptableObjects/Skins", order = 1)]
public class Skins : ScriptableObject
{
    [SerializeField] Material[] colorBodyColor;
    [SerializeField] Material[] pantsMat;
    public int ColorBodyAmount { get => colorBodyColor.Length; }
    public int PantAmount { get => pantsMat.Length; }

    public Material GetSkinColor(ColorType colorType)
    {
        return colorBodyColor[(int)colorType];
    }
   

    public Material GetSkinPants(PantType pantType)
    {
        return pantsMat[(int)pantType];
    }
}
