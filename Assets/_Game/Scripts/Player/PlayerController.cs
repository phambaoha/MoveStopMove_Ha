using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController, IHit
{
    [SerializeField]
    JoystickMove joystick;

    [SerializeField]
    Transform cam;


     int Cash = 0;

   // bool isTargetInRange;

    private void Start()
    {
        Cash = UserData.Instance.Cash;
        OnInit();
        ChangeWeaponHand(WeaponOnHandType.Axe);
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
            return;
        }


        if (IsMove())
        {
            ChangeAnim(Constants.TAG_ANIM_RUN);
            return;
        }
        else
        {
            if (IsTargetInRange(transform.position, radiusRangeAttack, Constants.TAG_BOT))
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
  

   
 

    public override void OnHit()
    {
        base.OnHit();

        // bat ui fail


        UIManager.Instance.OpenUI(UIID.UIC_Fail);
        GameManager.Instance.ChangeState(GameState.Menu);

    }
 

    public void PosUpCamera()
    {
        cam.GetComponent<CameraController>().offset.y += offSetScaleup.y;
    }

    public void SetCash(int num)
    {
        Cash += num;
    }

    public int GetCash()
    {
        return Cash;
    }
  

}
