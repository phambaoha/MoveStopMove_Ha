using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Hat : FindPlayer
{

    public HatType hatType;

    public bool unlocked  = false;

    [SerializeField]
    public Image imageLock;

    [SerializeField]
    public Image imageSelected;

    public int Price;

    public void SetDataHat()
    {
        switch (hatType)
        {
            case HatType.BunnyEar:
                {
                    UserData.Instance.SetBoolData(UserData.Key_BunnyUnlock, true);
                }
                break;
            case HatType.Hat:
                {
                    UserData.Instance.SetBoolData(UserData.Key_HatUnlock, true);
                }
                break;
            case HatType.Horn:
                {
                    UserData.Instance.SetBoolData(UserData.Key_HornUnlock, true);
                }
                break;

        }
    }

    public void GetDataHat()
    {
        switch (hatType)
        {
            case HatType.BunnyEar:
                {
                    unlocked = UserData.Instance.BunnyUnlocked;
                }
                break;
            case HatType.Hat:
                {
                    unlocked = UserData.Instance.HatUnlocked;
                }
                break;
            case HatType.Horn:
                {
                    unlocked = UserData.Instance.HornUnlocked;
                }
                break;


        }
    }
}



