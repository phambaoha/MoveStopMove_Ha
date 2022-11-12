using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : GameUnit
{
    //  bat buoc ke thua game unit



    public float speed;
    public Transform WeaponRender;

    private CharacterController character;
    public bool WeaponOfPlayer;

    public Transform weaponSize;

    public void Start()
    {
        TF.localScale = Vector3.one;
        Invoke(nameof(OnDespawn), 3f);
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
        TF.Translate(speed * Time.deltaTime * Vector3.forward);
      

    }



  
    void WeaponSizeUp()
    {
        if (character != null && character.quantityTargetKilled > 0)
        {
            TF.localScale = Vector3.one + new Vector3(0.05f, 0.05f, 0.05f) * character.quantityTargetKilled;

        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        IHit ihit = Cache.GetHit(other);

        if (ihit != null)
        {


            character.SizeUp();
            character.quantityTargetKilled++;

            ihit.OnHit();

            OnDespawn();
        }
    }

    internal void SetCharacter(CharacterController characterController)
    {
        character = characterController;
    }




}
