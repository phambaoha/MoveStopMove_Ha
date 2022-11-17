
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController : GameUnit, IHit
{
    // Start is called before the first frame update


    [SerializeField]
    protected Transform tranSizeUp;

    [SerializeField]
    SkinnedMeshRenderer skinMeshRen;

    [SerializeField]
    SkinnedMeshRenderer PantMeshRen;


    [Header("Scripable Object")]
    [SerializeField]
    Skins SObj_Skins;
    [SerializeField]
    WeaponSpecs SObj_WeaponSpecs;



    [SerializeField]
    int targetKilledQty = 0;
    public int TargetKilledQty { get => targetKilledQty; set => targetKilledQty = value; }


    [Header("canvas")]
    [SerializeField]
    TextMeshProUGUI textLevel;

    [SerializeField]
    WeaponOnHandType weaponHandType;

    [Header("    ")]
    private string curentAnim;

    public Animator playerAnim;

    public Rigidbody rb;


    public bool isDead = false;

    public float radiusRangeAttack;

    public Transform throwPoint;


    public float nextFire = 0f;

    public float fireRate;


    public ColorType colorType;

    public PantType pantType;





    public Vector3 offSetScaleup;


    [SerializeField]
    Transform posSpawnWeaponHand;

    WeaponHand weapon;


    public override void OnInit()
    {
     
        targetKilledQty = 0;

        SetTextLevel(targetKilledQty);

        isDead = false;

        ResetSize();

        ChangeAllSkin();

    }

    void ChangeAllSkin()
    {
        ChangeBodySkinMat((ColorType)Random.Range(0, SObj_Skins.ColorBodyAmount));

        ChangePantsMat((PantType)Random.Range(0, SObj_Skins.PantAmount));

        // gan weaponhand
        weaponHandType = SObj_WeaponSpecs.GetWeaponHand();

        ChangeWeaponHand();


    }

    void ChangeWeaponHand()
    {

         weapon = SimplePool.Spawn<WeaponHand>(SelectWeaponHand(weaponHandType), posSpawnWeaponHand.position, posSpawnWeaponHand.rotation);

        weapon.transform.SetParent(posSpawnWeaponHand);

        weapon.transform.localRotation = Quaternion.identity;
    }    


    Collider coll;
    // tim target trong tam tan cong
    public virtual bool IsTargetInRange(Vector3 center, float radius, string tag)
    {
      
        bool temp = false;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
             coll = hitColliders[i];
            if (coll.CompareTag(tag) && !Cache.GetCharacterController(coll.transform).isDead)
            {
                temp = true;
                break;
            }

        }

        transform.LookAt(coll.transform);
        return temp;
    }

    public virtual bool IsTargetInRange(Vector3 center, float radius, string tag_Player, string tag_Bot)
    {
        bool temp = false;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {

            Collider coll = hitColliders[i];
            if (coll.transform != this.transform)
            {
                if (hitColliders[i].CompareTag(tag_Player) || coll.CompareTag(tag_Bot))
                {

                    temp = true;
                    break;
                }

            }


        }


        return temp;
    }


    public virtual void ThrowAttack()
    {
        if (!isDead)
        {
            ChangeAnim(Constants.TAG_ANIM_ATTACK);

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                StartCoroutine(IDelayThrowWeapon());
            }
        }

    }

    IEnumerator IDelayThrowWeapon()
    {
        yield return Cache.GetWaitForSeconds(0.3f);
        Weapons weapons = SimplePool.Spawn<Weapons>(SelectWeapon(weaponHandType), throwPoint.position, throwPoint.rotation);
        weapons.OnInit();
        weapons.SetCharacter(this);
    }

    PoolType SelectWeapon(WeaponOnHandType weaponOnHandType)
    {
        PoolType temp = PoolType.None;

        switch (weaponOnHandType)
        {
            case WeaponOnHandType.Axe:
                {
                    temp = PoolType.Axe;
                }
                break;
            case WeaponOnHandType.Knife:
                {
                    temp = PoolType.Knife;
                }
                break;

            case WeaponOnHandType.Boomerang:
                {
                    temp = PoolType.Bommerang;
                }
                break;
        }

        return temp;
    }
    PoolType SelectWeaponHand(WeaponOnHandType weaponOnHandType)
    {
        PoolType temp = PoolType.None;

        switch (weaponOnHandType)
        {
            case WeaponOnHandType.Axe:
                {
                    temp = PoolType.Axe_WeaponsHand;break;
                }
                
            case WeaponOnHandType.Knife:
                {
                    temp = PoolType.Knife_WeaponsHand; break;
                }
               

            case WeaponOnHandType.Boomerang:
                {
                    temp = PoolType.Boomerang_WeaponsHand;break;
                }
                
        }

        return temp;
    }


    protected virtual void ChangeAnim(string animName)
    {
        if (curentAnim != animName)
        {
            playerAnim.ResetTrigger(animName);

            curentAnim = animName;

            playerAnim.SetTrigger(curentAnim);
        }
    }


    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
        SimplePool.Despawn(weapon);
    }

    public void ChangeBodySkinMat(ColorType colorType)
    {
        this.colorType = colorType;
        skinMeshRen.material = SObj_Skins.GetSkinColor(colorType);

    }

    public void ChangePantsMat(PantType pantType)
    {
        this.pantType = pantType;

        PantMeshRen.material = SObj_Skins.GetSkinPants(pantType);

    }



    // check dead
    public virtual void OnHit()
    {
        isDead = true;
        UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).setNumBot(LevelManagers.Instance.TotalBotAmount);

    }

    public void SetTextLevel(int num)
    {
        textLevel.text = num.ToString();
    }
    public void SizeUp()
    {
        if (tranSizeUp != null)
            tranSizeUp.localScale += offSetScaleup;
    }

    public void ResetSize()
    {
        tranSizeUp.localScale = Vector3.one;
    }


}
