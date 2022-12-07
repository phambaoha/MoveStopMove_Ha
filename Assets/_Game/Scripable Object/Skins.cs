using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Skins", menuName = "ScriptableObjects/Skins", order = 1)]
public class Skins : ScriptableObject
{
    [SerializeField] Material[] colorBodyColor;
    [SerializeField] Material[] pantsMat;

    [SerializeField] Transform[] Hat;

    public int GetColorBodyAmount { get => colorBodyColor.Length; }
   

    public Material GetSkinColor(ColorType colorType)
    {
        return colorBodyColor[(int)colorType];
    }


    public int GetPantAmount { get => pantsMat.Length; }
    public Material GetSkinPants(PantType pantType)
    {
        return pantsMat[(int)pantType];
    }


    public int GetHatAmount { get => Hat.Length; }

    public Hat GetHat(HatType hatType)
    {
        if ((int)hatType < 0)
            return Cache.GetHat(Hat[ (int) HatType.None]);

        return Cache.GetHat(Hat[(int)hatType]);
    }

    public HatType GetHatType(HatType hatType)
    {
        return hatType;

    }


}
