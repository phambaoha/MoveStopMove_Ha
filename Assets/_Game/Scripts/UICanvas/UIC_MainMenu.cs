using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIC_MainMenu : UICanvas
{
    public TextMeshProUGUI level;

    public override void Setup()
    {
        base.Setup();
       // level.text = "Level " +  PlayerPrefs.GetInt("level", 1).ToString();
    }

    public void StartGameButton()
    {
        LevelManagers.Instance.OnStart();
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
    }
}
