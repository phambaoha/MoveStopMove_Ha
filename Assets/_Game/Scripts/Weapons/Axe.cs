using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapons
{


    public override void OnInit()
    {
        base.OnInit();
        WeaponRender.Rotate(Vector3.up * -360 * Time.deltaTime, Space.World);
    }

   
}
