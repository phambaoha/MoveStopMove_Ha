using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{


    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(45, 0, 0));
    }
}
