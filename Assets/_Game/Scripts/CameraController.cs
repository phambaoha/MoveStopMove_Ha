using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float speed;
    [SerializeField]
   public Vector3 offset;
    [SerializeField]
    Transform TF;

    Transform playerTF;


    private void Awake()
    {

         playerTF = FindObjectOfType<PlayerController>().transform;

    }
    // Update is called once per frame
    private void LateUpdate()
    {
        if(GameManager.Instance.IsState(GameState.Menu))
        {
            TF.position = new Vector3(1, 1f, -1.5f);
            TF.rotation = Quaternion.identity;
        } 
        
        else
        {
            if(GameManager.Instance.IsState(GameState.GamePlay))
            {
                TF.position = Vector3.Lerp(TF.position, playerTF.position + offset, speed * Time.deltaTime);
                TF.rotation = Quaternion.Euler(60,0,0);
            }    
            
        }    

    

   
    }



}
