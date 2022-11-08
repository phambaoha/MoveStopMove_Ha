using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : GameUnit, IHit
{
    // Start is called before the first frame update


    [SerializeField]
    protected List<Weapons> ListWeapons = new List<Weapons>();

    private string curentAnim;

    public Animator playerAnim;

    public Rigidbody rb;

   
    public bool isDead = false;

    public float radiusRangeAttack;

    public Transform throwPoint;

    private float nextFire = 0f;

    public float fireRate = 3f;


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
        SimplePool.Spawn(ListWeapons[ListWeapons.Count - 1], throwPoint.position, throwPoint.rotation).OnInit();
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


    // nhan damge
    public void OnHit()
    {
        isDead = true;

    }

    public override void OnInit()
    {
       
    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}
