using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIC_ChangeSkin : UICanvas
{

    [SerializeField]
     public TextMeshProUGUI textCash;



    private void Awake()
    {

        textCash.text = UserData.Instance.Cash.ToString();
    }


    public void BackToMainMenu()
    {
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
    }






}
