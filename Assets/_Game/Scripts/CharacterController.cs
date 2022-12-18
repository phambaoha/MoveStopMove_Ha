
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
    Transform posSpawnWeaponHand;

    [SerializeField]
    protected Transform PosSpawnHat;

    [SerializeField]
    SkinnedMeshRenderer skinMeshRen;

    [SerializeField]
    SkinnedMeshRenderer PantMeshRen;

    [SerializeField]
    int targetKilledQty = 0;
    public int TargetKilledQty { get => targetKilledQty; set => targetKilledQty = value; }



    [Header("Scripable Object")]
    [SerializeField]
    protected SkinSO skinSO;
    [SerializeField]
    protected WeaponSO weaponSO;



    [Header("canvas")]
    [SerializeField]
    TextMeshProUGUI textLevel;



    [Header(" Skin Object")]
    protected WeaponHand weaponHand;
    protected Hat hat;



    private string curentAnim;

    [HideInInspector]
    public float nextFire = 0f;
    [HideInInspector]
    public Vector3 offSetScaleup = new Vector3(0.02f, 0.02f, 0.02f);
    [HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public Animator playerAnim;


    public float fireRate;
    public float radiusRangeAttack;
    public Transform throwPoint;

    [Header("Type ")]
    public ColorType colorType;

    public PantType pantType;

    // phan biet type cua weapon hand
    public WeaponOnHandType weaponHandType;

    public HatType hatType;


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
        ChangeBodySkinMat((ColorType)Random.Range(0, skinSO.GetColorBodyAmount));

        //  ChangePantsMat((PantType)Random.Range(0, SObj_Skins.GetPantAmount));
        if (weaponHand != null)
            weaponHand.gameObject.SetActive(true);
    }

    private void Update()
    {

    }

    public virtual bool IsTargetInRange(Vector3 center, float radius, string tag)
    {

        Collider coll;
        bool temp = false;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            coll = hitColliders[i];
            if (coll.transform != TF && coll.CompareTag(tag) && !Cache.GetCharacterController(coll.transform).isDead)
            {
                this.TF.LookAt(coll.transform);
                temp = true;
                break;
            }
        }

        return temp;
    }

    public virtual bool IsTargetInRange(Vector3 center, float radius, string tag_Player, string tag_Bot)
    {

        Collider coll = null;
        bool temp = false;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            coll = hitColliders[i];

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




    public virtual void ChangeAnim(string animName)
    {
        if (curentAnim != animName)
        {
            playerAnim.ResetTrigger(animName);

            curentAnim = animName;

            playerAnim.SetTrigger(curentAnim);
        }
    }

    public void ChangeBodySkinMat(ColorType colorType)
    {
        this.colorType = colorType;
        skinMeshRen.material = skinSO.GetSkinColor(colorType);

    }

    public void ChangePantsMat(PantType pantType)
    {
        this.pantType = pantType;

        PantMeshRen.material = skinSO.GetSkinPants(pantType);

    }

    //void ChangeRandomWeaponHand()
    //{

    //    WeaponOnHandType temp  = (WeaponOnHandType)Random.Range(0, SObj_Weapon.WeaponHandAmount);

    //    weaponHandType = SObj_Weapon.GetTypeWeaponHand(temp);

    //    weaponHand = Instantiate<WeaponHand>(SObj_Weapon.GetWeaponHand(temp), posSpawnWeaponHand.position, posSpawnWeaponHand.rotation);

    //    weaponHand.transform.SetParent(posSpawnWeaponHand);

    //    weaponHand.transform.localRotation = Quaternion.identity;
    //}

    public void ChangeWeaponHand(WeaponOnHandType weaponHandType)
    {

        if (weaponHand != null)
        {
            Destroy(weaponHand.gameObject);
        }

        this.weaponHandType = weaponHandType;

        weaponHand = Instantiate<WeaponHand>(weaponSO.GetWeaponHand(weaponHandType), posSpawnWeaponHand.position, posSpawnWeaponHand.rotation);

        weaponHand.transform.SetParent(posSpawnWeaponHand);

        weaponHand.transform.localRotation = Quaternion.identity;
    }



    // Hat curentHat;
    public virtual void ChangeHat(HatType hatType)
    {

        if (hat != null)
        {
            Destroy(hat.gameObject);
        }


        this.hatType = hatType;

        if (this.hatType == HatType.None)
            return;

        hat = Instantiate<Hat>(skinSO.GetHat(hatType), PosSpawnHat.position, PosSpawnHat.rotation);

        hat.transform.SetParent(PosSpawnHat);

        hat.transform.localRotation = Quaternion.identity;


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


    public virtual void ThrowAttack()
    {
        if (isDead)
            return;

        if (!isDead)
        {

            if (Time.time > nextFire)
            {

                StartCoroutine(IDelayThrowWeapon());
                nextFire = Time.time + fireRate;

            }


            ChangeAnim(Constants.TAG_ANIM_ATTACK);


            SoundManager.Instance.ThrowWeapon();



        }

    }

    IEnumerator IDelaySetWeaponTrue()
    {
        yield return new WaitForSeconds(0.3f);
        weaponHand.gameObject.SetActive(true);
      
    }

    IEnumerator IDelayThrowWeapon()
    {



        yield return Cache.GetWaitForSeconds(0.4f);

        weaponHand.gameObject.SetActive(false);


        Weapons weapons = SimplePool.Spawn<Weapons>(SelectWeapon(weaponHandType), throwPoint.position, throwPoint.rotation);
        weapons.OnInit();
        weapons.SetCharacter(this);


        // hien lai vu khi sau khi nem
        StartCoroutine(IDelaySetWeaponTrue());
    }


    [SerializeField]
    public List<ParticleSystem> listParticleHealing;

    [SerializeField]
    public List<ParticleSystem> ListParticleBlood;

    // check dead
    public virtual void OnHit()
    {


        isDead = true;

        ChangeAnim(Constants.TAG_ANIM_DEAD);

        UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).SetNumBot(LevelManagers.Instance.TotalBotAmount);


        ParticlePool.Play(ListParticleBlood[0], TF.position, TF.rotation);


        SoundManager.Instance.Died();
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

    public override void OnDespawn()
    {

    }
}
