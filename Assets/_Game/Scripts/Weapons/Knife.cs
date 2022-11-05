using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapons
{
    public override void OnInit()
    {

        base.OnInit();
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}
