using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapons
{
 
  
    public override void OnInit()
    {
        base.OnInit();
        WeaponRender.Rotate( -360 * Time.deltaTime * Vector3.up, Space.World);
    }

   

}
