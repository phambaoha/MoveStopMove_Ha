using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIC_GamePlay : UICanvas
{
    [SerializeField]
    TextMeshProUGUI textTotalBot;

    [SerializeField]
    TextMeshProUGUI textCash;

    private void Start()
    {
        SetNumBot(LevelManagers.Instance.TotalBotAmount);


        UserData.Instance.OnInitData();

        SetCash(UserData.Instance.Cash);

    }

    public void SetNumBot(int num)
    {
        textTotalBot.text = num.ToString();
    }

    public override void Close()
    {
        base.Close();
    }

    public void SetCash(int num)
    {
        textCash.text = num.ToString();
    }

}
