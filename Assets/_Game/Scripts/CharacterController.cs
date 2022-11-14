using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController : GameUnit, IHit
{
    // Start is called before the first frame update

    [SerializeField]
    protected List<Weapons> ListWeapons = new List<Weapons>();

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
    Pants SObj_Pants;

    [SerializeField]
    int targetKilledAmount = 0;


    [Header("canvas")]
    [SerializeField]
    TextMeshProUGUI textLevel;


    [Header("    ")]
    private string curentAnim;

    public Animator playerAnim;

    public Rigidbody rb;

    [HideInInspector]
    public bool isDead = false;

    public float radiusRangeAttack;

    public Transform throwPoint;


    private float nextFire = 0f;

    public float fireRate = 3f;


    public ColorType colorType;

    public PantType pantType;







    public int QuantityTargetKilled { get => targetKilledAmount; set => targetKilledAmount = value; }



    private void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        
        targetKilledAmount = 0;

        SetTextLevel(targetKilledAmount);

        isDead = false;

        ResetSize();

        ChangeAllSkin();
       
    }

    void ChangeAllSkin()
    {
        ChangeBodySkinMat((ColorType)Random.Range(0, SObj_Skins.Amount));

        ChangePantsMat((PantType)Random.Range(0, SObj_Pants.Amount));

    }


    // tim target trong tam tan cong
    public virtual bool IsTargetInRange(Vector3 center, float radius, string tag)
    {
        bool temp = false;
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {

            if (hitCollider.CompareTag(tag) && !Cache.GetCharacterController(hitCollider.transform).isDead)
            {
                transform.LookAt(hitCollider.transform.position);

                temp = true;

            }

        }
        return temp;
    }

    public virtual bool IsTargetInRange(Vector3 center, float radius, string tag_Player, string tag_Bot)
    {
        bool temp = false;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (int i = 2; i < hitColliders.Length; i++)
        {
            if (hitColliders[i] != this.gameObject )
            {
                if (hitColliders[i].CompareTag(tag_Player) || hitColliders[i].CompareTag(tag_Bot))
                {
                    transform.LookAt(hitColliders[i].transform.position);

                    temp = true;

                }
            }
            else
                temp = false;
        }


        return temp;
    }
    public virtual void ThrowAttack()
    {
        if (isDead)
            return;



        ChangeAnim(Constants.TAG_ANIM_ATTACK);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(IDelayThrowWeapon());

          
        }
    }

    IEnumerator IDelayThrowWeapon()
    {
        yield return Cache.GetWaitForSeconds(0.3f);
        Weapons weapons = SimplePool.Spawn<Weapons>(PoolType.Knife, throwPoint.position, throwPoint.rotation);
        weapons.OnInit();
        weapons.SetCharacter(this);



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
    }

    public void ChangeBodySkinMat(ColorType colorType)
    {
        this.colorType = colorType;
        skinMeshRen.material = SObj_Skins.GetSkinColor(colorType);

    }

    public void ChangePantsMat(PantType pantType)
    {
        this.pantType = pantType;

        PantMeshRen.material = SObj_Pants.GetSkinPants(pantType);


    }

    public virtual void OnHit()
    {
        isDead = true;
        int num =  LevelManagers.Instance.TotalBotAmount--;
        UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).setNumBot(num);
        
    }

   public void SetTextLevel(int num)
    {
        textLevel.text = num.ToString();
    }
    public void SizeUp()
    {
        if (tranSizeUp != null)
            tranSizeUp.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }


    public void ResetSize()
    {
        tranSizeUp.localScale = Vector3.one;
    }
}
