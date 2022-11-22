using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapons
{

    public override void OnInit()
    {

        base.OnInit();
        TF.Translate(SObj_weaponSpecs.speedKnife * Time.deltaTime * Vector3.forward);
    }

    private void Update()
    {
        OnInit();
    }



}
