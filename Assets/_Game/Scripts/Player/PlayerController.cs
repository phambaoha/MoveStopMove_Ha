using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField]
    JoystickMove joystick;

    public Transform TF;

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
                return;
            }
            else
            {
                ChangeAnim(Constants.TAG_ANIM_IDLE);

            }


        }
    }

    public override void ThrowAttack()
    {
        base.ThrowAttack();
      //  StartCoroutine(IDelayAttack());

    }

    IEnumerator IDelayAttack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
    }






}
