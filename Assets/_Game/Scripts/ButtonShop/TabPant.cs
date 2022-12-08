using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabPant : UIC_ChangeSkin
{

    [SerializeField]
    List<Button> ListButtonPant;
    Button curentBtnPant;



    private void Start()
    {
        curentBtnPant = ListButtonPant[0];


        for (int i = 0; i < ListButtonPant.Count; i++)
        {

            Cache.GetBtn_Pant(ListButtonPant[i]).GetDataPant();

            if (Cache.GetBtn_Pant(ListButtonPant[i]).pantUnlocked)
            {
                Cache.GetBtn_Pant(ListButtonPant[i]).imageLock.enabled = false;
            }
            else
            {
                Cache.GetBtn_Pant(ListButtonPant[i]).imageLock.enabled = true;
            }




        }
    }

    public void SelectedButton(Button btn)
    {


        curentBtnPant = btn;

        player.ChangePantsMat(Cache.GetBtn_Pant(curentBtnPant).pantType);


        UserData.Instance.OnInitData();


        Cache.GetBtn_Pant(curentBtnPant).GetDataPant();


        // bat tat button

        // bat tat image select
        for (int i = 0; i < ListButtonPant.Count; i++)
        {
            Cache.GetBtn_Pant(ListButtonPant[i]).imageSelected.gameObject.SetActive(false);


        }
        Cache.GetBtn_Pant(curentBtnPant).imageSelected.gameObject.SetActive(true);





        if (Cache.GetBtn_Pant(curentBtnPant).pantUnlocked)
        {
            EnableButtonEquip();

        }
        else
        {
            EnableButtonBuy();

        }
    }

    public void Equip()
    {
        player.ChangePantsMat(Cache.GetBtn_Pant(curentBtnPant).pantType);

        UserData.Instance.SetIntData(UserData.Key_CurentPant, (int)Cache.GetBtn_Pant(curentBtnPant).pantType);
    }

    public void Buy()
    {
        if (player.GetCash() >= Cache.GetBtn_Pant(curentBtnPant).Price)
        {
            int price = -Cache.GetBtn_Pant(curentBtnPant).Price;

            ChangeCash(price);

            Cache.GetBtn_Pant(curentBtnPant).pantUnlocked = true;

            Cache.GetBtn_Pant(curentBtnPant).SetDataPant();


            EnableButtonEquip();
        }
        else
        {
            EnableNofication();
        }
    }



    public override void EnableButtonBuy()
    {
        base.EnableButtonBuy();

        Cache.GetBtn_Pant(curentBtnPant).imageLock.enabled = true;
    }

    public override void EnableButtonEquip()
    {
        base.EnableButtonEquip();

        Cache.GetBtn_Pant(curentBtnPant).imageLock.enabled = false;
    }



    public void PreviewPant()
    {

      
    }






}
