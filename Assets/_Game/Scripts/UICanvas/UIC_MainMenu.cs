using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIC_MainMenu : UICanvas
{
    public TextMeshProUGUI level;

    public TextMeshProUGUI textCash;

    private void Start()
    {
        
    }
    public override void Setup()
    {
        base.Setup();

        textCash.text = UserData.Instance.Cash.ToString();
 
    }

    public void StartGameButton()
    {
        

        SoundManager.Instance.ClickButton();
        GameManager.Instance.ChangeState(GameState.GamePlay);
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_GamePlay);
       
    }

    public void ChangeSkinButton()
    {
        SoundManager.Instance.ClickButton();
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_ChangeSkin);
    }

    public void ChangeWeaponButton()
    {
        SoundManager.Instance.ClickButton();

        Close();
        UIManager.Instance.OpenUI(UIID.UIC_ChangeWeapon);
    }    

    
}
