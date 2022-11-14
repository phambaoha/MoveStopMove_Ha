using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : GameUnit
{
    //  bat buoc ke thua game unit

    [SerializeField]

   protected WeaponSpecs SObj_weaponSpecs;

   // public float speed;
    public Transform WeaponRender;



    private CharacterController character;
    public Transform weaponSize;

    public float timeDespawn;

    public void Start()
    {
        TF.localScale = Vector3.one;
        Invoke(nameof(OnDespawn), timeDespawn);
    }

    public void Update()
    {
        OnInit();
    }
    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }


    public override void OnInit()
    {
        WeaponSizeUp();

    }



  
    void WeaponSizeUp()
    {
        if (character != null && character.QuantityTargetKilled > 0)
        {
            TF.localScale = Vector3.one + new Vector3(0.05f, 0.05f, 0.05f) * character.QuantityTargetKilled;

        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        IHit ihit = Cache.GetHit(other);

        if (ihit != null)
        {


            character.SizeUp();
            character.QuantityTargetKilled++;

            character.SetTextLevel(character.QuantityTargetKilled);

            ihit.OnHit();

            OnDespawn();
        }
    }

    internal void SetCharacter(CharacterController characterController)
    {
        character = characterController;
    }




}
