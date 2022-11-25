using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRenderWeapon : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0.0f, 1f, Space.World);

    }
}
