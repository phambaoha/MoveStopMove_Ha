using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Btn_Pant : MonoBehaviour
{
    public PantType pantType;

    public bool pantUnlocked = false;

    [SerializeField]
    public Image imageLock;

    [SerializeField]
    public Image imageSelected;

    public int Price;



    public void SetDataPant()
    {
        UserData.Instance.SetDataState(UserData.Key_Pant, (int)(pantType), 1);

        //switch (pantType)
        //{
        //    case PantType.Orion:
        //        {
        //            UserData.Instance.SetBoolData(UserData.Key_OrionUnlock, true);
        //        }
        //        break;
        //    case PantType.Pokemon:
        //        {
        //            UserData.Instance.SetBoolData(UserData.Key_PokemonUnlock, true);
        //        }
        //        break;
        //    case PantType.RainBow:
        //        {
        //            UserData.Instance.SetBoolData(UserData.Key_RainbowUnlock, true);
        //        }
        //        break;

        //}
    }

    public void GetDataPant()
    {
        if (UserData.Instance.GetDataState(UserData.Key_Pant, (int)(pantType)) == 1)
            pantUnlocked = true;



        //switch (pantType)
        //{
        //    case PantType.Orion:
        //        {
        //            pantUnlocked = UserData.Instance.OnionUnlocked;
        //        }
        //        break;
        //    case PantType.Pokemon:
        //        {
        //            pantUnlocked = UserData.Instance.PokemonUnlocked;
        //        }
        //        break;
        //    case PantType.RainBow:
        //        {
        //            pantUnlocked = UserData.Instance.RainBowUnlocked;
        //        }
        //        break;


            //}
    }
}
