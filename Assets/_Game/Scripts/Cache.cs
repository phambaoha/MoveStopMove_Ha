using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Cache 
{
   static readonly Dictionary<Collider, IHit> CacheComponent = new Dictionary<Collider, IHit>();

    public static IHit GetHit(Collider coll)
    {
        if (!CacheComponent.ContainsKey(coll))
            CacheComponent.Add(coll, coll.GetComponent<IHit>());
        return CacheComponent[coll];

    }


    static readonly Dictionary<float, WaitForSeconds> CacheWaitforSenconds = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWaitForSeconds(float t)
    {
        if (!CacheWaitforSenconds.ContainsKey(t))
            CacheWaitforSenconds.Add(t, new WaitForSeconds(t));
        return CacheWaitforSenconds[t];
    }

    static readonly Dictionary<Transform, CharacterController> CacheCharacterController = new Dictionary<Transform, CharacterController>();

    public static CharacterController GetCharacterController(Transform trans)
    {
        if (!CacheCharacterController.ContainsKey(trans))
            CacheCharacterController.Add(trans, trans.GetComponent<CharacterController>());
        return CacheCharacterController[trans];
    }

    static readonly Dictionary<Transform, Hat> CacheHat = new Dictionary<Transform, Hat>();

    public static Hat GetHat(Transform trans)
    {
        if (!CacheHat.ContainsKey(trans))
            CacheHat.Add(trans, trans.GetComponent<Hat>());
        return CacheHat[trans];
    }


    static readonly Dictionary<Transform, WeaponHand> CacheWeaponHand = new Dictionary<Transform, WeaponHand>();

    public static WeaponHand GetWeaponHand(Transform trans)
    {
        if (!CacheWeaponHand.ContainsKey(trans))
            CacheWeaponHand.Add(trans, trans.GetComponent<WeaponHand>());
        return CacheWeaponHand[trans];
    }

    static readonly Dictionary<Button, Btn_Hat> CacheBtn_Hat = new Dictionary<Button, Btn_Hat>();

    public static Btn_Hat GetBtn_Hat(Button btn)
    {
        if (!CacheBtn_Hat.ContainsKey(btn))
            CacheBtn_Hat.Add(btn, btn.GetComponent<Btn_Hat>());
        return CacheBtn_Hat[btn];
    }

    static readonly Dictionary<Transform, WeaponRender> CacheWeaponRender = new Dictionary<Transform, WeaponRender>();

    public static WeaponRender GetWeaponRender(Transform trans)
    {
        if (!CacheWeaponRender.ContainsKey(trans))
            CacheWeaponRender.Add(trans, trans.GetComponent<WeaponRender>());
        return CacheWeaponRender[trans];
    }





}
