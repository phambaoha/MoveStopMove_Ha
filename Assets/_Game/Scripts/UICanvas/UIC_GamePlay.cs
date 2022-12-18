using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIC_GamePlay : UICanvas
{
    [SerializeField]
    TextMeshProUGUI textTotalBot;

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        SoundManager.Instance.OnInit();
        SetNumBot(LevelManagers.Instance.TotalBotAmount);
    }
    public void SetNumBot(int num)
    {
        textTotalBot.text = num.ToString();
    }

    public override void Close()
    {
        base.Close();
    }

    public void Setting()
    {
        SoundManager.Instance.ClickButton();
        Close();

        GameManager.Instance.ChangeState(GameState.Menu);
        UIManager.Instance.OpenUI<UIC_Setting>(UIID.UIC_Setting);
    }

   

}
