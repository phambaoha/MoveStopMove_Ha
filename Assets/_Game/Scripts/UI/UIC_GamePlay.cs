using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIC_GamePlay : UICanvas
{
    public override void Close()
    {
       // JoystickControl.direct = Vector3.zero;
        base.Close();
    }
}
