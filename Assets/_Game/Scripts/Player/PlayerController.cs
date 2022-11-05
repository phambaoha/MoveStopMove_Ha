using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField]
    JoystickMove joystick;

   public Transform TF;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {

        isTargetInRange = IsTargetInRange(transform.position, radiusRangeAttack, Constants.TAG_BOT);

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



    public override void ThrowAttack()
    {
        base.ThrowAttack();

        StartCoroutine(IDelayAttack());
      
    }

    IEnumerator IDelayAttack()
    {
        yield return new WaitForSeconds(0.8f);
        isAttack = false;
    }






}
