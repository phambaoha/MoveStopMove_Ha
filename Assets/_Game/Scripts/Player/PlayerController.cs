using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController, IHit
{
    [SerializeField]
    JoystickMove joystick;

    [SerializeField]
    Transform cam;



    bool isTargetInRange;

    private void Start()
    {
        OnInit();
    }
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
                
          //      if(Time.time > nextFire)
              //  {
                    ThrowAttack();
              //      nextFire = Time.time + fireRate;
               // }

               
              
            }
            else
            {
                ChangeAnim(Constants.TAG_ANIM_IDLE);

                return;

            }


        }
    }
  

    IEnumerator IDelayDestroy()
    {

        yield return Cache.GetWaitForSeconds(1.5f);
        this.gameObject.SetActive(false);

    }
    public override void OnInit()
    {
        base.OnInit();

    }

    public override void OnHit()
    {
        base.OnHit();

        // bat ui fail
        UIManager.Instance.OpenUI(UIID.UIC_Fail);


    }

    public void PosUpCamera()
    {
        cam.GetComponent<CameraController>().offset.y += offSetScaleup.y;
    }


}
