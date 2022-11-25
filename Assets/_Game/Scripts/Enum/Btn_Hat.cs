using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Hat : FindPlayer
{

    public HatType hatType;

    public bool unlocked = false;

    [SerializeField]
    Image imageLock;

    [SerializeField]
    Button button;

    [SerializeField]
    public Image imageSelected;

    [SerializeField]
    List<Button> listButton;

    public bool isSelectedButton;

    public int Price;

    [SerializeField]
    TextMeshProUGUI noficationEnoughCash;


    

    private void Start()
    {
        foreach (var item in listButton)
        {
           GetSkinData(item);
        }

    }


    void GetSkinData(Button item)
    {
      HatType temp = Cache.GetBtn_Hat(item).hatType;

        switch (temp)
        {
            case HatType.BunnyEar:
                {
                    Cache.GetBtn_Hat(item).unlocked = UserData.Instance.BunnyUnlocked;

                    SetupButton(item);
                }
                break;
            case HatType.Hat:
                {
                    Cache.GetBtn_Hat(item).unlocked = UserData.Instance.HatUnlocked;
                    SetupButton(item);
                }
                break;
            case HatType.Horn:
                {
                    Cache.GetBtn_Hat(item).unlocked = UserData.Instance.HornUnlocked;

                    SetupButton(item);
                }
                break;
           
            default:
                break;
        }
       
    }

    // thay doi hinh anh mo khoa cua button
    void SetupButton(Button item)
    {

        if (Cache.GetBtn_Hat(item).unlocked)
        {
            Cache.GetBtn_Hat(item).imageLock.enabled = false;
            Cache.GetBtn_Hat(item).imageSelected.enabled = true;
        }
        else
        {
            Cache.GetBtn_Hat(item).imageLock.enabled = true;
            Cache.GetBtn_Hat(item).imageSelected.enabled = false;
        }

    }


    // lua chon button khi bam vao
    public void SelectHatType()
    {
        foreach (var item in listButton)
        {
            Cache.GetBtn_Hat(item).imageSelected.gameObject.SetActive(false);
            Cache.GetBtn_Hat(item).isSelectedButton = false;

        }
        imageSelected.gameObject.SetActive(true);
        isSelectedButton = true;


        if (isSelectedButton)
        {
            if (unlocked)
            {
                button.GetComponentInChildren<Text>().text = "Equip";
                Equip();
                imageLock.enabled = false;
            }
            else
            {

                button.onClick.AddListener(() => Buy());
                button.GetComponentInChildren<Text>().text = "Buy  " + Price.ToString();
            }
        }
    }

    // mua san pham
    public void Buy()
    {

        if (isSelectedButton)
        {
            if (player.GetCash() >= Price)
            {
                foreach (var item in listButton)
                {

                    SaveSkinData(item);

                }
                player.SetCash(-Price);

                UserData.Instance.SetIntData(UserData.Key_Cash,player.GetCash());

                UIManager.Instance.OpenUI<UIC_ChangeSkin>(UIID.UIC_ChangeSkin).textCash.text = player.GetCash().ToString();

                imageLock.enabled = false;
                unlocked = true;
                button.GetComponentInChildren<Text>().text = "Equip";

                if (unlocked)
                {
                    Equip();
                }
            }
            else
            {
                button.onClick.AddListener(() => SelectHatType());
            }


        }
    }

    void SaveSkinData(Button item)
    {
        if (Cache.GetBtn_Hat(item).isSelectedButton)
        {
            HatType temp = Cache.GetBtn_Hat(item).hatType;
            switch (temp)
            {
                case HatType.BunnyEar:
                    {
                        UserData.Instance.SetIntData(UserData.Key_BunnyUnlock, 1);
                    }
                    break;
                case HatType.Hat:
                    {
                        UserData.Instance.SetIntData(UserData.Key_HatUnlock, 1);
                    }
                    break;
                case HatType.Horn:
                    {
                        UserData.Instance.SetIntData(UserData.Key_HornUnlock,  1);
                    }
                    break;
              
                default:
                    break;
            }
        }
    }

    // trang bi
    public void Equip()
    {
        button.onClick.AddListener(() => player.ChangeHat(hatType));
    }







}
