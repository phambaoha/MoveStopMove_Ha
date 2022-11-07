using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float speed;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    Transform TF;

    Transform playerTF;
    private void Awake()
    {

         playerTF = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(TF.position, playerTF.position + offset, speed * Time.deltaTime);
    }
   
}
