using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{


    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {

       
        Move();

        print("is attack " + isAttack);
        print(" is move " + IsMoving);

       

    }

   
 

   

}
