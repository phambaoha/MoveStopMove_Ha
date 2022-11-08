using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : GameUnit
{
    //  bat buoc ke thua game unit


    public float speed;
    public Transform WeaponRender;
    public void Start()
    {
        Invoke(nameof(OnDespawn), 3f);
    }

    public void Update()
    {
        OnInit();
    }
    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }


    public override void OnInit()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
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
