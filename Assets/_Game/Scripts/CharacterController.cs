using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, IHit
{
    // Start is called before the first frame update


    [SerializeField]
    protected List<Weapons> ListWeapons = new List<Weapons>();

    private string curentAnim;

  
    protected bool isAttack = true;

   

    
   // private bool isMoving; 
  //  protected bool IsMoving { get => rb.velocity != Vector3.zero; set => isMoving = value; }

    public Animator playerAnim;

    public Rigidbody rb;


    public float radiusRangeAttack;

    public Transform throwPoint;

    private float nextFire=0f;

    public float fireRate = 3f;


  
  

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

    public virtual bool IsTargetInRange(Vector3 center, float radius, string tag_Player,string tag_Bot )
    {
        bool temp = false;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);


        for (int i = 2; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag(tag_Player) || hitColliders[i].CompareTag(tag_Bot))
            {
                transform.LookAt(hitColliders[i].transform.position);

                temp = true;

            }
        }

 
        return temp;
    }
    public virtual void ThrowAttack()
    {
        ChangeAnim(Constants.TAG_ANIM_ATTACK);

        if (Time.time >= nextFire)
        {
            StartCoroutine(IDelayThrowWeapon());
            nextFire = Time.time + fireRate;
        }
    }

    IEnumerator IDelayThrowWeapon()
    {
        yield return new WaitForSeconds(0.3f);
     
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
        Destroy(this.gameObject);
    }
}
