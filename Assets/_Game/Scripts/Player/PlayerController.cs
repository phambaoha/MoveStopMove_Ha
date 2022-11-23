using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController, IHit
{
    [SerializeField]
    JoystickMove joystick;

    [SerializeField]
    Transform cam;


   // bool isTargetInRange;

    private void Start()
    {
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
            //    TF.LookAt(targetofPlayer);
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

        StartCoroutine(IDelayDestroy());

        // bat ui fail
        UIManager.Instance.OpenUI(UIID.UIC_Fail);
        GameManager.Instance.ChangeState(GameState.Menu);

    }
    IEnumerator IDelayDestroy()
    {

        yield return Cache.GetWaitForSeconds(1.5f);
        this.gameObject.SetActive(false);

    }

    public void PosUpCamera()
    {
        cam.GetComponent<CameraController>().offset.y += offSetScaleup.y;
    }


}
