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

    public float upgradeRange;



    public void SetDataPant()
    {
        UserData.Instance.SetDataState(UserData.Key_Pant, (int)(pantType), 1);

    }

    public void GetDataPant()
    {
        if (UserData.Instance.GetDataState(UserData.Key_Pant, (int)(pantType)) == 1)
            pantUnlocked = true;




    }
}
