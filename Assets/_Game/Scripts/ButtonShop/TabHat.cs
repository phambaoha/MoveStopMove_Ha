using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabHat : UIC_ChangeSkin
{


    [SerializeField]
    List<Button> listButtonHat;
    Button curentBtnHat;


    private void Start()
    {

        curentBtnHat = listButtonHat[0];


        for (int i = 0; i < listButtonHat.Count; i++)
        {
        
            Cache.GetBtn_Hat(listButtonHat[i]).GetDataHat();

            if (Cache.GetBtn_Hat(listButtonHat[i]).unlocked)
            {

                SetImageLock(listButtonHat[i], false);
            }
            else
            {
                SetImageLock(listButtonHat[i], true) ;
              
            }
        }
    }

 
    public void SelectButton(Button btn)
    {
        curentBtnHat = btn;

        player.ChangeHat(Cache.GetBtn_Hat(curentBtnHat).hatType);

        UserData.Instance.OnInitData();


        Cache.GetBtn_Hat(curentBtnHat).GetDataHat();
   



        for (int i = 0; i < listButtonHat.Count; i++)
        {

            Cache.GetBtn_Hat(listButtonHat[i]).imageSelected.gameObject.SetActive(false);
        }

        Cache.GetBtn_Hat(curentBtnHat).imageSelected.gameObject.SetActive(true);


        if (Cache.GetBtn_Hat(curentBtnHat).unlocked)
        {
            EnableButtonEquip();
        }
        else
        {
            EnableButtonBuy();
        }

    }

    public void Buy()
    {
        if (player.GetCash() >= Cache.GetBtn_Hat(curentBtnHat).Price)
        {
            int price = -Cache.GetBtn_Hat(curentBtnHat).Price;

            ChangeCash(price);


            Cache.GetBtn_Hat(curentBtnHat).unlocked = true;


            //SetDataHat(curentBtnHat);

            Cache.GetBtn_Hat(curentBtnHat).SetDataHat();



            EnableButtonEquip();
        }

        else
        {
            EnableNofication();
        }

    }

  

    public void Equip()
    {
        player.ChangeHat(Cache.GetBtn_Hat(curentBtnHat).hatType);
        UserData.Instance.SetIntData(UserData.Key_CurrentHat, (int)Cache.GetBtn_Hat(curentBtnHat).hatType);
    }


    public override void EnableButtonBuy()
    {
        base.EnableButtonBuy();
        SetImageLock(curentBtnHat, true);
    }

    public override void EnableButtonEquip()
    {
        base.EnableButtonEquip();

        SetImageLock(curentBtnHat, false);
        
    }



    void SetImageLock(Button btn, bool _bool)
    {
        Cache.GetBtn_Hat(btn).imageLock.enabled = _bool;
    }

    
}
