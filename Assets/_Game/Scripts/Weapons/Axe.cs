using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapons
{
    private void Start()
    {
        Invoke(nameof(OnDespawn), 3f);
    }

    public override void OnInit()
    {
        base.OnInit();
        WeaponRender.Rotate(Vector3.up * -360 * Time.deltaTime, Space.World);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        SimplePool.Despawn(this);
    }

}
