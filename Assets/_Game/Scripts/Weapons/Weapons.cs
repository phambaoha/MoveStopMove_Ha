using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : GameUnit
{
    //  bat buoc ke thua game unit

    [SerializeField]

   protected WeaponSObj SObj_weaponSpecs;

   // public float speed;
    public Transform WeaponRender;
    private CharacterController character;
  //  public Transform weaponSize;

    public float timeDespawn;
    public void Update()
    {
        OnInit();
    }
    public override void OnDespawn()
    {
        SimplePool.Despawn(this);

        CancelInvoke();
    }


    public override void OnInit()
    {

        Invoke(nameof(OnDespawn), timeDespawn);
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
