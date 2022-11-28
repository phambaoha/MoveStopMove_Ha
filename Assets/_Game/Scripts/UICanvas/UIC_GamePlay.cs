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

   

}
