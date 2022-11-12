using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
   // [SerializeField]
   // Transform mainCamera;
    // Start is called before the first frame update

    private void Awake()
    {
       // mainCamera = FindObjectOfType<CameraController>().transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(45, 0, 0));
    }
}
