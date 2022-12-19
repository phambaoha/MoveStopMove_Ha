using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{

   // public CharacterData playerDataSO;

  //  public float speed;

    public DynamicJoystick dynamicJoystick;


    [SerializeField]
    PlayerController playerController;

    private void Update()
    {
        if (GameManager.Instance.IsState(GameState.GamePlay))
        {
           
            MoveByJoystick();

        }
     

    }

    public void MoveByJoystick()
    {

        if (playerController.isDead)
            return;

        playerController.rb.velocity = new Vector3(dynamicJoystick.Horizontal * playerController.playerDataSO.speed, playerController.rb.velocity.y, dynamicJoystick.Vertical * playerController.playerDataSO.speed);

        // tinh goc xoanh cua nhan vat
        float angleA = Mathf.Atan2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical) * Mathf.Rad2Deg;

        if (angleA != 0)
            transform.rotation = Quaternion.Euler(0f, angleA, 0f);

    }


}
