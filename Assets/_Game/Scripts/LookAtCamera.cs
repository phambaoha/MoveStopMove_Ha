using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void LateUpdate()
    {
        if(GameManager.Instance.IsState(GameState.GamePlay))
        {
           
            transform.rotation = Quaternion.Euler(new Vector3(45, 0, 0));
           
        }
        
        if (GameManager.Instance.IsState(GameState.Menu))
        {
            transform.rotation = Quaternion.Euler(new Vector3(180, 0, 0));
        }
    }
}
