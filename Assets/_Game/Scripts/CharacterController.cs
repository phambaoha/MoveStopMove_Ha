using System.Collections;
using System.Collections.Generic;
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


    [Header("    ")]
    private string curentAnim;

    public Animator playerAnim;

    public Rigidbody rb;


    public bool isDead = false;

    public float radiusRangeAttack;

    public Transform throwPoint;

    private float nextFire = 0f;

    public float fireRate = 3f;

    public ColorType colorType;

    public PantType pantType;


    [SerializeField]
    int targetKilled = 0;

    public int quantityTargetKilled { get => targetKilled; set => targetKilled = value; }

    private void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        targetKilled = 0;

        isDead = false;
        ResetSize();

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

            if (hitCollider != null && (hitCollider.CompareTag(tag)))
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
            if (hitColliders[i] != this.gameObject)
            {
                if (hitColliders[i].CompareTag(tag_Player) || hitColliders[i].CompareTag(tag_Bot))
                {
                    transform.LookAt(hitColliders[i].transform.position);

                    temp = true;

                }
            }


        }


        return temp;
    }
    public virtual void ThrowAttack()
    {

        ChangeAnim(Constants.TAG_ANIM_ATTACK);

        if (Time.time > nextFire)
        {

            StartCoroutine(IDelayThrowWeapon());

            nextFire = Time.time + fireRate;
        }
    }

    IEnumerator IDelayThrowWeapon()
    {
        yield return Cache.GetWaitForSeconds(0.3f);
        Weapons weapons = SimplePool.Spawn<Weapons>(ListWeapons[ListWeapons.Count - 1], throwPoint.position, throwPoint.rotation);
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
        LevelManagers.Instance.SetTotalBotAmount();
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
