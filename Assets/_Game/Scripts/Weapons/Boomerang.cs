using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapons
{
    Vector3 dir;


    public override void OnInit()
    {
        base.OnInit();

        dir = Vector3.forward;

        StartCoroutine(IBoomerangBack());
    }


    IEnumerator IBoomerangBack()
    {
        yield return new WaitForSeconds(0.8f);
        dir = Vector3.back;
    }

    void Update()
    {

        TF.Translate(SObj_weaponSpecs.speedBoomerang * Time.deltaTime * dir);

        WeaponRender.Rotate(-360 * Time.deltaTime * Vector3.up, Space.World);
    }


}
