using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRender : MonoBehaviour
{

   public WeaponOnHandType weaponOnHandType;

    public bool unlocked = false;

    public int Price;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0.0f, 1f, Space.World);

    }



}
