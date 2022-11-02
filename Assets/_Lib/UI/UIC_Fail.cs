using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIC_Fail : UICanvas
{
    public void RetryButton()
    {
     //   LevelManager.Instance.RetryLevel();
        Close();

        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
    }
}
