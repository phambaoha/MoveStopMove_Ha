using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIC_MainMenu : UICanvas
{
    public TextMeshProUGUI level;

    // public TextMeshProUGUI textCash;

    public Image Mute;
    public Image unMute;
    public override void Setup()
    {
        base.Setup();


        OnInit();

     //   textCash.text = UserData.Instance.Cash.ToString();
 
    }

    void OnInit()
    {

 


        player.TF.position = new Vector3(1, 1, 2);

        player.ChangeAnim(Constants.TAG_ANIM_IDLE);

        player.TF.rotation = Quaternion.Euler(0, 150, 0);
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


    public void ChangeMute()
    {

        unMute.enabled = !unMute.enabled;
        Mute.enabled = !Mute.enabled;

        SoundManager.Instance.Mute();
    }

    
}
