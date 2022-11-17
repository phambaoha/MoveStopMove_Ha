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
  //  public Transform weaponSize;

    public float timeDespawn;

    public void Start()
    {

       
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
        TF.localScale = Vector3.one;

        if (character != null && character.TargetKilledQty >= 0)
        {
            
            TF.localScale = Vector3.one + new Vector3(0.05f, 0.05f, 0.05f) * character.TargetKilledQty;
        }
            
    }
   

    private void OnTriggerEnter(Collider other)
    {
        IHit ihit = Cache.GetHit(other);

        if (ihit != null && other.transform != character.transform )
        {
            character.SizeUp();
            character.TargetKilledQty++;
            character.SetTextLevel(character.TargetKilledQty);

            if(character as PlayerController)
            {
                PlayerController player = (PlayerController)character;
                player.PosUpCamera();
            }
          
            ihit.OnHit();
            OnDespawn();
        }
    }

    internal void SetCharacter(CharacterController characterController)
    {
        character = characterController;
    }




}
