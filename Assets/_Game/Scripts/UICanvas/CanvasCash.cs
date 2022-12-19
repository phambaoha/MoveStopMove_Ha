using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCash : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textCash;

 
    private void Start()
    {
        UserData.Instance.OnInitData();
        SetCash(UserData.Instance.Cash);
    }

    public void SetCash(int num)
    {
        textCash.text = num.ToString();
    }
}
