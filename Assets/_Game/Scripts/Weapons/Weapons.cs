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
    [HideInInspector]
    public CharacterController character;
    //  public Transform weaponSize;

    public float timeDespawn;


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

    // scaleup vu khi dua tren level hien tai
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

      //  IHit ihit = other.gameObject.GetComponent<IHit>();

        if (ihit != null && other.transform != character.transform)
        {
            character.SizeUp();
            character.TargetKilledQty++;
            character.SetTextLevel(character.TargetKilledQty);

            if (character as PlayerController)
            {
                PlayerController player = (PlayerController)character;

                player.PosUpCamera();

                player.SetCash(10);


                // UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).SetCash(player.GetCash());

                player.SetTextCash(player.GetCash());


                UserData.Instance.SetIntData(UserData.Key_Cash, player.GetCash());

                ParticlePool.Play(player.listParticle[1], player.TF.position, player.TF.rotation);
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
