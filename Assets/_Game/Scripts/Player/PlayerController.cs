using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField]
    JoystickMove joystick;

    //public new  Transform TF;

    bool isTargetInRange;



    // Update is called once per frame
    void Update()
    {

        Move();

    }

    public bool IsMove()
    {
        return rb.velocity != Vector3.zero;
    }

    void Move()
    {

        if (isDead)
        {

            ChangeAnim(Constants.TAG_ANIM_DEAD);
            StartCoroutine(IDelayDestroy());
            return;
        }


        isTargetInRange = IsTargetInRange(transform.position, radiusRangeAttack, Constants.TAG_BOT);


        if (IsMove())
        {
            ChangeAnim(Constants.TAG_ANIM_RUN);
            return;
        }
        else
        {

            if (isTargetInRange)
            {

                ThrowAttack();
                
            }
            else
            {
                ChangeAnim(Constants.TAG_ANIM_IDLE);

                return;

            }


        }
    }
    public override void ThrowAttack()
    {
        base.ThrowAttack();
       

    }

     IEnumerator IDelayDestroy()
    {

        yield return Cache.GetWaitForSeconds(1.5f);

        this.gameObject.SetActive(false);

    }








}
