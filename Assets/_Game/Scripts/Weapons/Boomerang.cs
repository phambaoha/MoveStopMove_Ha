using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapons
{


    public override void OnInit()
    {
        base.OnInit();
     

        TF.Translate(SObj_weaponSpecs.speedAxe * Time.deltaTime * Vector3.forward);
        
        
        WeaponRender.Rotate(-360 * Time.deltaTime * Vector3.up, Space.World);
    }

  
    void Update()
    {
        OnInit();
    }

}
