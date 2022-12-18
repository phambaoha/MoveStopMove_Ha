using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Transform playerController;

    private void LateUpdate()
    {
        transform.position = playerController.transform.position;
    }
}
