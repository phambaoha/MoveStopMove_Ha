using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    List<Weapons> ListWeapons = new List<Weapons>();

    [SerializeField]
    protected JoystickMove joystick;

   

    private string curentAnim;

    protected bool isAttack;

    protected bool isTargetInRange;

    private bool isMoving;
    protected bool IsMoving { get => rb.velocity != Vector3.zero; set => isMoving = value; }

    public Animator playerAnim;

    public Rigidbody rb;


    public float radiusRangeAttack;

    public Transform throwPoint;

    float nextFire;

    readonly float fireRate = 3f;


    


    protected virtual void Move()
    {
        isTargetInRange = IsTargetInRange(transform.position, radiusRangeAttack);

        if (IsMoving)
        {
            isAttack = true;

            ChangeAnim(Constants.TAG_ANIM_RUN);
        }
        else
        {
            if (isTargetInRange && isAttack)
            {

                ThrowAttack();
                return;
            }

            ChangeAnim(Constants.TAG_ANIM_IDLE);
        }

    }


    protected virtual bool IsTargetInRange(Vector3 center, float radius)
    {
        bool temp = false;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(Constants.TAG_BOT))
            {
                transform.LookAt(hitCollider.transform.position);
               
                temp = true;

            }

        }

        return temp;


    }

    protected virtual void ThrowAttack()
    {

        ChangeAnim(Constants.TAG_ANIM_ATTACK);
        StartCoroutine(IDelayAttack());
        if (Time.time > nextFire)
        {
            SimplePool.Spawn(ListWeapons[ListWeapons.Count - 1], throwPoint.position, Quaternion.Euler(-90, 0, 0)).OnInit();
           // Instantiate(ListWeapons[ListWeapons.Count - 1], throwPoint.position, Quaternion.Euler(-90,0,0));
            nextFire = Time.time + fireRate;
        }



    }

    IEnumerator IDelayAttack()
    {
        yield return new WaitForSeconds(0.8f);
        isAttack = false;
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

}
