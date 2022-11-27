using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIC_ChangeSkin : UICanvas
{

    [SerializeField]
    public TextMeshProUGUI textCash;
    HatType currentHatType;

    [SerializeField]
    List<Button> listButton;

    Button curentBtnHat;


    [SerializeField]
    Button btnBuy;

    [SerializeField]
    Button btnEquip;

    private void Awake()
    {

        textCash.text = UserData.Instance.Cash.ToString();

        curentBtnHat = listButton[0];
        currentHatType = HatType.BunnyEar;

        for (int i = 0; i < listButton.Count; i++)
        {
            if (Cache.GetBtn_Hat(listButton[i]).hatType == HatType.BunnyEar)
                Cache.GetBtn_Hat(listButton[i]).unlocked = UserData.Instance.BunnyUnlocked;

            if (Cache.GetBtn_Hat(listButton[i]).hatType == HatType.Hat)
                Cache.GetBtn_Hat(listButton[i]).unlocked = UserData.Instance.HatUnlocked;

            if (Cache.GetBtn_Hat(listButton[i]).hatType == HatType.Horn)
                Cache.GetBtn_Hat(listButton[i]).unlocked = UserData.Instance.HornUnlocked;


            if (Cache.GetBtn_Hat(listButton[i]).unlocked)
            {
                Cache.GetBtn_Hat(listButton[i]).imageLock.enabled = false;
            }
            else
            {
                Cache.GetBtn_Hat(listButton[i]).imageLock.enabled = true;
            }
        }


       


    }

    private void Update()
    {
        print(UserData.Instance.BunnyUnlocked);
    }


    public void BackToMainMenu()
    {
        Close();
        UIManager.Instance.OpenUI(UIID.UIC_MainMenu);
    }




    

    public void SelectedBunny()
    {

        currentHatType = HatType.BunnyEar;

        CurrentSelectButton();



    }
    public void SelectedHat()
    {

        currentHatType = HatType.Hat;

        CurrentSelectButton();




    }
    public void SelectedHorn()
    {

        currentHatType = HatType.Horn;

        CurrentSelectButton();






    }


    void CurrentSelectButton()
    {
      
        for (int i = 0; i < listButton.Count; i++)
        {
            Cache.GetBtn_Hat(curentBtnHat).imageSelected.gameObject.SetActive(false);

    

            if (Cache.GetBtn_Hat(listButton[i]).hatType == currentHatType)
            {

                curentBtnHat = listButton[i];

            }
        }
        curentBtnHat.GetComponent<Btn_Hat>().imageSelected.gameObject.SetActive(true);



        UserData.Instance.OnInitData();

        switch (curentBtnHat.GetComponent<Btn_Hat>().hatType)
        {
            case HatType.BunnyEar:
                {
                    Cache.GetBtn_Hat(curentBtnHat).unlocked = UserData.Instance.BunnyUnlocked;
                }
                break;
            case HatType.Hat:
                {
                    Cache.GetBtn_Hat(curentBtnHat).unlocked = UserData.Instance.HatUnlocked;
                }
                break;
            case HatType.Horn:
                {
                    Cache.GetBtn_Hat(curentBtnHat).unlocked = UserData.Instance.HornUnlocked;
                }
                break;
            
            default:
                break;
        }



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
           

            Cache.GetBtn_Hat(curentBtnHat).unlocked = true;

            if (Cache.GetBtn_Hat(curentBtnHat).hatType == HatType.BunnyEar)
            {
                UserData.Instance.SetBoolData(UserData.Key_BunnyUnlock, true);

            }
            if (Cache.GetBtn_Hat(curentBtnHat).hatType == HatType.Hat)
            {
                UserData.Instance.SetBoolData(UserData.Key_HatUnlock, true);

            }
            if (Cache.GetBtn_Hat(curentBtnHat).hatType == HatType.Horn)
            {
                UserData.Instance.SetBoolData(UserData.Key_HornUnlock, true);
              
            }


            EnableButtonEquip();
        }

    }
    public void Equip()
    {
        player.ChangeHat(currentHatType);
    }


    void EnableButtonBuy()
    {
        btnBuy.gameObject.SetActive(true);
        btnEquip.gameObject.SetActive(false);

        Cache.GetBtn_Hat(curentBtnHat).imageLock.enabled = true;
    }

    void EnableButtonEquip()
    {
        btnBuy.gameObject.SetActive(false);
        btnEquip.gameObject.SetActive(true);

        Cache.GetBtn_Hat(curentBtnHat).imageLock.enabled = false;
    }


}
