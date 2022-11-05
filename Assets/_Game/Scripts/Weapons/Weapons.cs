using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : GameUnit
{
    //  bat buoc ke thua game unit
    //  

    public float speed;
    public Transform WeaponRender;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        IHit ihit = Cache.GetHit(other);
       
        if (ihit != null)
        {
            ihit.OnHit();
            OnDespawn();
        }
    }



}
