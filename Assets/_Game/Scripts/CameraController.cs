using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    public float speed;
    [SerializeField]
    Vector3 offset;
    private void Awake()
    {

        player = FindObjectOfType<PlayerController>().transform;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, speed * Time.deltaTime);
    }
}
