using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIC_Fail : UICanvas
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

    public void Menu()
    {
        LevelManagers.Instance.OnInit();
        UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).OnInit();
        Close();
        UIManager.Instance.GetUI<UIC_GamePlay>(UIID.UIC_GamePlay).Close();

        player.TF.position = Vector3.one;

        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
    }
}
