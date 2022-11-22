using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIC_MainMenu : UICanvas
{
    //public TextMeshProUGUI level;



    public override void Setup()
    {
        base.Setup();
       // level.text = "Level " +  PlayerPrefs.GetInt("level", 1).ToString();
    }

    public void StartGameButton()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
       
    }

    public void ChangeSkinButton()
    {
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_ChangeSkin);
    }

    public void ChangeWeaponButton()
    {
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_ChangeWeapon);
    }    

    
}
