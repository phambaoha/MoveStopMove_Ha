using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIC_Victory : UICanvas
{
   
    public void RetryButton()
    {
        LevelManagers.Instance.OnInit();

        UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).OnInit();

        LevelManagers.Instance.RetryLevel(LevelManagers.Instance.indexLevel);  

        Close();

        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
        GameManager.Instance.ChangeState(GameState.GamePlay);
    }

    public void Nextlevel()
    {
        LevelManagers.Instance.OnInit();

        GameManager.Instance.ChangeState(GameState.GamePlay);

        LevelManagers.Instance.indexLevel++;

        if(LevelManagers.Instance.indexLevel > 3)
        {
            LevelManagers.Instance.indexLevel = 1;
        }

        LevelManagers.Instance.LoadLevel(LevelManagers.Instance.indexLevel);

        UserData.Instance.SetIntData(UserData.Key_Level, LevelManagers.Instance.indexLevel);

        UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).OnInit();

        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
    }
}
