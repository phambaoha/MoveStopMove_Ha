using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIC_ChangeSkin : UICanvas
{
    
    public Button btnBuy;
    
    public Button btnEquip;

    public TextMeshProUGUI noficationCashEnough;


    public void BackToMainMenu()
    {
        UserData.Instance.OnInitData();
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);

        player.ChangePantsMat((PantType)UserData.Instance.CurentPant);

        player.ChangeHat((HatType) UserData.Instance.CurrentHat);
    }

    public virtual void EnableButtonBuy()
    {
        btnBuy.gameObject.SetActive(true);
        btnEquip.gameObject.SetActive(false);

    }

    public virtual void EnableButtonEquip()
    {
        btnBuy.gameObject.SetActive(false);
        btnEquip.gameObject.SetActive(true);

    }

   public void ChangeCash(int price)
    {
        player.SetCash(price);
        player.SetTextCash(player.GetCash());
        UserData.Instance.SetIntData(UserData.Key_Cash, player.GetCash());
    }


    public void EnableNofication()
    {
        noficationCashEnough.gameObject.SetActive(true);
        StartCoroutine(IDisableNofication());
    }

    IEnumerator IDisableNofication()
    {
        yield return new WaitForSeconds(0.8f);
        noficationCashEnough.gameObject.SetActive(false);
    }








}
