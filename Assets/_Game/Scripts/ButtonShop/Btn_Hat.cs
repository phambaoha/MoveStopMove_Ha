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
    public Image imageLock;

    [SerializeField]
    public Image imageSelected;

    public int Price;

    public bool IsUpgrade = false;

    public float upgradeSpeed;

    public void SetDataHat()
    {

        UserData.Instance.SetDataState(UserData.Key_Hat, (int)(hatType), 1);
    }

    public void GetDataHat()
    {

        if (UserData.Instance.GetDataState(UserData.Key_Hat, (int)(hatType)) == 1)
            unlocked = true;
   
    }
}



