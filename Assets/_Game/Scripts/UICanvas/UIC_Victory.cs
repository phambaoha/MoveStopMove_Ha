using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIC_Victory : UICanvas
{
    public void RetryButton()
    {
        LevelManagers.Instance.TotalBotAmount = 10;
        LevelManagers.Instance.RetryLevel();  
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
        GameManager.Instance.ChangeState(GameState.GamePlay);
    }

    public void Nextlevel()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        LevelManagers.Instance.LoadLevel(2);
        LevelManagers.Instance.TotalBotAmount = 10;
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
    }
}
