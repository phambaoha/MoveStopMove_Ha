using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSObj", menuName = "ScriptableObjects/WeaponSObj", order = 1)]
public class WeaponSObj : ScriptableObject
{
    public int speedAxe;
    public int speedKnife;

    [SerializeField]
    Transform[] WeaponHand;
  
    public int WeaponHandAmount { get => WeaponHand.Length; }

    public WeaponHand GetWeaponHand(WeaponOnHandType weaponHand)
    {
      

        return Cache.GetWeaponHand(WeaponHand[(int)weaponHand]);
    }

    public WeaponOnHandType GetTypeWeaponHand(WeaponOnHandType weaponHand)
    {
        return weaponHand;
     
    }    


}
