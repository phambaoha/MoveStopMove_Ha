using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIC_Fail : UICanvas
{
    
    public void RetryButton()
    {
        LevelManagers.Instance.RetryLevel(LevelManagers.Instance.indexLevel);
        GameManager.Instance.ChangeState(GameState.GamePlay);
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
    }


    public void Menu()
    {
        Close();
        player.TF.position = new Vector3(1, 1, 1);

        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
    }    
}
