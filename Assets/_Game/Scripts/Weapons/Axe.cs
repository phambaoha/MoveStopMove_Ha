using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapons
{

    private void Start()
    {
        Invoke(nameof(OnDespawn), 3f);
    }


    private void Update()
    {
        OnInit();
    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

     
    public override void OnInit()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        WeaponRender.Rotate(Vector3.up, -180 * Time.deltaTime, Space.World);
    }
}
