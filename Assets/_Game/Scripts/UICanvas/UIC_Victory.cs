using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIC_Victory : UICanvas
{
    public void RetryButton()
    {
        LevelManagers.Instance.TotalBotAmount = 5;
        LevelManagers.Instance.RetryLevel(LevelManagers.Instance.indexLevel);  
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
        GameManager.Instance.ChangeState(GameState.GamePlay);
    }

    public void Nextlevel()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);

        LevelManagers.Instance.indexLevel++;

        if(LevelManagers.Instance.indexLevel > 3)
        {
            LevelManagers.Instance.indexLevel = 1;
        }

        LevelManagers.Instance.LoadLevel(LevelManagers.Instance.indexLevel);

        UserData.Instance.SetIntData(UserData.Key_Level, LevelManagers.Instance.indexLevel);

        LevelManagers.Instance.TotalBotAmount = 5;
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
    }
}
