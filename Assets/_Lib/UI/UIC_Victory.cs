using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIC_Victory : UICanvas
{
    public void RetryButton()
    {
      //  LevelManager.Instance.RetryLevel();
        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
        Close();
    }

    public void BackMainMenuButton()
    {
     //   LevelManager.Instance.NextLevel();
        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
        Close();
    }
}
