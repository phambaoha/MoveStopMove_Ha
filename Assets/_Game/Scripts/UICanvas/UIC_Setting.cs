using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIC_Setting : UICanvas
{
    public GameObject Mute;
    public GameObject unMute;


    public override void Close()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        base.Close();
    }

    public void ReturnHome()
    {
        Close();
        GameManager.Instance.ChangeState(GameState.Menu);
        UIManager.Instance.OpenUI<UIC_MainMenu>(UIID.UIC_MainMenu);
    }

    public void Continue()
    {
        Close();

        GameManager.Instance.ChangeState(GameState.GamePlay);

        UIManager.Instance.OpenUI<UIC_MainMenu>(UIID.UIC_GamePlay);

    }


    public void ChangeMute()
    {

        if(unMute.activeSelf)
        {
            Mute.SetActive(true);
            unMute.SetActive(false);
        }  
        else
        {
            Mute.SetActive(false);
            unMute.SetActive(true);
        }    
     
        SoundManager.Instance.Mute();
    }


}
