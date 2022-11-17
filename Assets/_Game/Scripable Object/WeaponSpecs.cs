using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSpecs", menuName = "ScriptableObjects/WeaponSpecs", order = 1)]
public class WeaponSpecs : ScriptableObject
{
    public int speedAxe;
    public int speedKnife;

    [SerializeField]
    Transform[] WeaponHand;

    public int WeaponHandAmount { get => WeaponHand.Length; }

    public Transform GetWeaponHand(WeaponOnHandType weaponOnHandType)
    {
        return WeaponHand[(int)weaponOnHandType];
    }

    public WeaponOnHandType GetWeaponHand()
    {
        return (WeaponOnHandType)Random.Range(0, WeaponHand.Length);
    }    


}
