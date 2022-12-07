using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : CharacterController, IHit
{
    [SerializeField]
    JoystickMove joystick;

    [SerializeField]
    Transform cam;



    [Header("canvas c")]
    [SerializeField]
    TextMeshProUGUI textCash;



    int Cash = 0;

    // bool isTargetInRange;

    private void Start()
    {
        Cash = UserData.Instance.Cash;
        OnInit();



        ChangeWeaponHand((WeaponOnHandType)UserData.Instance.CurentWeapon);

        ChangeHat((HatType)UserData.Instance.CurrentHat);

        //  ChangePantsMat();


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


    public void SetTextCash(int num)
    {
        textCash.text = num.ToString();
    }


}
