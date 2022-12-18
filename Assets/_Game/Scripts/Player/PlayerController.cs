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

    public bool victory;


    private bool targetInRange;

    private void Start()
    {
        Cash = UserData.Instance.Cash;

        OnInit();

    }

    public override void OnInit()
    {
        base.OnInit();

        targetInRange = false;

        ChangeWeaponHand((WeaponOnHandType)UserData.Instance.CurentWeapon);

        ChangeHat((HatType)UserData.Instance.CurrentHat);

        ChangePantsMat((PantType)UserData.Instance.CurentPant);

        victory = false;


        TF.SetPositionAndRotation(Vector3.one, Quaternion.Euler(0, 150, 0));

    }
    void FixedUpdate()
    {
        Move();
    }



    public bool IsMove()
    {
        return rb.velocity != Vector3.zero;
    }



    void Move()
    {

        targetInRange = IsTargetInRange(this.TF.position, radiusRangeAttack, Constants.TAG_BOT);

        if (isDead)
        {
            return;
        }

        if (victory)
        {
            TF.SetPositionAndRotation(Vector3.one, Quaternion.Euler(0, 150, 0));
            ChangeAnim(Constants.TAG_ANIM_VICTORY);
            return;
        }



        if (IsMove())
        {
            ChangeAnim(Constants.TAG_ANIM_RUN);
            return;
        }

        if(!IsMove())
        {
            if (targetInRange)
            {

                ThrowAttack();
                return;

            }

            ChangeAnim(Constants.TAG_ANIM_IDLE);
        }    
      

    }





    // check player dead
    public override void OnHit()
    {

        base.OnHit();

        // bat ui fail

        UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).Close();

        UIManager.Instance.OpenUI(UIID.UIC_Fail);


        GameManager.Instance.ChangeState(GameState.Menu);

        SoundManager.Instance.GameOver();

        SimplePool.CollectAll();

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
